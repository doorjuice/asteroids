using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public float movementSpeed = 0.5f;

    private Vector3 rotation, translation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        translation = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation, rotationSpeed * Time.deltaTime);
        transform.position += translation * Time.deltaTime;

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
    }
}
