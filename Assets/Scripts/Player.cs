using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5f, rotationSpeed = 150f;

    public GameObject missile, canon;
    public GameObject explosion;
    public GameObject messageDeath;

    public GameObject bonusVies;

    public float temps = 30f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Rotate(0, 0, -rotation * Time.deltaTime);

        float translation = Input.GetAxis("Vertical") * movementSpeed;
        transform.Translate(0, translation*Time.deltaTime, 0, Space.Self);

        var newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x, -9, 9);
        newPos.y = Mathf.Clamp(newPos.y, -5, 5);
        transform.position = newPos;

        if (Input.GetKeyDown("space"))
        {
            Instantiate(missile, canon.transform.position, canon.transform.rotation);
        }

        temps -= Time.deltaTime;
        Debug.Log($"Life time set at 30, remaining: {temps}");
        if (temps < 0)
        {
            SceneManager.LoadScene("MenuScene");
        }
        Instantiate(bonusVies);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Brigand"))
        {
            Instantiate(gameObject, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            Time.timeScale = 0;

            SceneManager.LoadScene("MenuScene");
        }
        else if (other.transform.parent)
        {
            if (other.transform.parent.gameObject.CompareTag("Brigand"))
            {
                Instantiate(gameObject, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(other.gameObject);
                Time.timeScale = 0;

                SceneManager.LoadScene("MenuScene");
            }
        }
    }

    public void Explode()
    {
        Destroy(gameObject);
        Time.timeScale = 0;

        SceneManager.LoadScene("MenuScene");
    }
}
