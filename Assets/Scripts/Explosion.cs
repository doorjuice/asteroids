using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float duration = 1.0f;
    public float finalSize = 5f;

    private Vector3 initScale;
    private float timeElapsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        initScale = transform.localScale; 
        Destroy(gameObject, duration); // L'explosion va disparaitre après 'duration' secondes
        // Équivalent à Invoke("Destroy", timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        transform.localScale = initScale * (finalSize * timeElapsed / duration);
        //transform.localScale = 1.001f * (1 + Time.deltaTime) * scale;
    }
}
