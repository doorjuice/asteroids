using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaisseauTirailleur : MonoBehaviour
{
    public float distanceMinimum = 2f;
    public float vitesseRotation = 70f;
    public float vitesseMouvement = 0.5f;

    private float timer = 0.0f;
    private float waitTime = 1f;

    public GameObject missile, canon;
    public GameObject explosion;
    public GameObject messageMort;

    public GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

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

        if (timer > waitTime)
        {

            timer = timer - waitTime;

            Instantiate(missile, canon.transform.position, canon.transform.rotation);
        }
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}
