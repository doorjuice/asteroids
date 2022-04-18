using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float movementSpeed = 5f;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, movementSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); // Detruire le missile
        Instantiate(explosion, other.transform.position, other.transform.rotation); // Creer une explosion
        if (other.CompareTag("Asteroid"))
        {
            other.transform.GetComponent<Asteroid>()?.Explode();
        }
        else
        {
            if (other.transform.parent)
            {
                if (other.transform.parent.gameObject.CompareTag("Player"))
                {
                    other.transform.GetComponent<Player>()?.Explode();
                    Destroy(other.transform.parent.gameObject);
                }
            }
            else
            {
                if (other.CompareTag("Player"))
                {
                    other.transform.GetComponent<Player>()?.Explode();
                    Destroy(other.transform.parent.gameObject);
                }
            }
        }
    }
}
