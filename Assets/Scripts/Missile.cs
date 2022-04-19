using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float movementSpeed = 5f;

    public GameObject explosion;
    public vaisseauBrigand vBrigand;

    // Start is called before the first frame update
    void Start()
    {
        vBrigand = FindObjectOfType<vaisseauBrigand>();
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
          else if (other.CompareTag("Brigand"))
        {
            other.transform.GetComponent<vaisseauBrigand>()?.Explode();
        }
        else if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<Player>()?.Explode();
            Destroy(other.gameObject);
        }
        else if (other.transform.parent)
        {
            if (other.transform.parent.gameObject.CompareTag("Brigand"))
            {
                other.transform.parent.gameObject.GetComponent<vaisseauBrigand>()?.Explode();
                if (!vBrigand.isAlive())
                {
                    Destroy(other.transform.parent.gameObject);
                }
            }
            else if (other.transform.parent.gameObject.CompareTag("Player"))
            {
                other.transform.parent.gameObject.GetComponent<Player>()?.Explode();
                Destroy(other.transform.parent.gameObject);
            }
        }
    }
}
