using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{

    void Awake()
    {
        GetComponent<BoxCollider2D>().enabled = false; // disable coin's collider component
        GetComponent<SpriteRenderer>().enabled = false; // disable coin's sprite renderer component
    }

    // Update is called once per frame
    void Update()
    {

    }
}
