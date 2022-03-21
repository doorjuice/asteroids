using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public readonly float timeToLive = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", 1.0f);
        Destroy(gameObject, timeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        var scale = transform.localScale;
        transform.localScale = 1.001f * (1 + Time.deltaTime) * scale;
    }
}
