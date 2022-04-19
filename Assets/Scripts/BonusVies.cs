using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusVies : MonoBehaviour
{
    public float vitesseRotation = 60f;
    public float vitesseMouvement = 0.5f;

    private Vector3 rotation, translation;
    public float tempsApparition = 10f;

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        translation = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation, vitesseRotation * Time.deltaTime);
        transform.position += translation * Time.deltaTime; //equivalent à transform.Translate(translation * Time.deltaTime, Space.World);

        if (Mathf.Abs(transform.position.x) > 9f)
        {
            var newPos = transform.position;
            newPos.x = -transform.position.x;
            transform.position = newPos;
        }
        if (Mathf.Abs(transform.position.y) > 5f)
        {
            var newPos = transform.position;
            newPos.y = -transform.position.y;
            transform.position = newPos;
        }

        tempsApparition -= Time.deltaTime;
        Debug.Log($"Life time set at 10, remaining: {tempsApparition}");
        if (tempsApparition <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.temps++;
        }
    }
}
