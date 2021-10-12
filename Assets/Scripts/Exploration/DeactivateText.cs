using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateText : MonoBehaviour
{

    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false; // disable coin's sprite renderer component
    }

    // Update is called once per frame
    void Update()
    {

    }
}