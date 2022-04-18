using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vaisseauBrigand : MonoBehaviour
{

    public float distanceMinimum = 0f;

    public float vitesseRotation = 40f;
    public float vitesseMouvement = 5f;

    public GameObject explosion;

    public GameObject playerObj;
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("PlayerShip");
        rotation = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation, vitesseRotation * Time.deltaTime);

        if (playerObj)
        {
            var deltaX = playerObj.transform.position.x - transform.position.x;
            var deltaY = playerObj.transform.position.y - transform.position.y;

            if (Mathf.Abs(deltaX) > distanceMinimum)
            {
                var signeX = deltaX / Mathf.Abs(deltaX);
                transform.Translate(vitesseMouvement * Time.deltaTime * signeX, 0, 0, Space.Self);
            }
            else if (Mathf.Abs(deltaX) < distanceMinimum)
            {
                var signeX = (deltaX / Mathf.Abs(deltaX)) * -1;
                transform.Translate(vitesseMouvement * Time.deltaTime * signeX, 0, 0, Space.Self);
            }

            if (Mathf.Abs(deltaY) > distanceMinimum)
            {
                var signeY = deltaY / Mathf.Abs(deltaY);
                transform.Translate(0, vitesseMouvement * Time.deltaTime * signeY, 0, Space.Self);
            }
            else if (Mathf.Abs(deltaY) < distanceMinimum)
            {
                var signeY = (deltaY / Mathf.Abs(deltaY)) * -1;
                transform.Translate(0, vitesseMouvement * Time.deltaTime * signeY, 0, Space.Self);
            }

            if (Mathf.Abs(deltaX) > distanceMinimum || Mathf.Abs(deltaY) > distanceMinimum)
            {
                var newPos = transform.position;
                newPos.x = Mathf.Clamp(newPos.x, -9, 9);
                newPos.y = Mathf.Clamp(newPos.y, -5, 5);
                transform.position = newPos;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Time.timeScale = 0;
        }
    }
}
