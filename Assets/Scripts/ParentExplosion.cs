using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentExplosion : MonoBehaviour
{
    public Component parent;

    void Start()
    {
        parent = transform.parent.GetComponent("Player");

    }

    void OnTriggerEnter(Collider aCol)
    {
        //parent.gameObject.OnTriggerEnter(collider, aCol); // pass the own collider and the one we've hit
    }
}
