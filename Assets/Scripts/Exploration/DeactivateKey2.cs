using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateKey2 : MonoBehaviour
{
    public bool once; // variable used later to enable objects inspector component once
    public bool collected; // variable used later to detect whether player has collected this object

    public DialogueBox2 value; // create value to reference another script
    AudioSource ring; // create new audio source variable
    
    void Awake()
    {
        GetComponent<BoxCollider2D>().enabled = false; // disable coin's collider component
        GetComponent<SpriteRenderer>().enabled = false; // disable coin's sprite renderer component

        value = GameObject.Find("Dialogue").GetComponent<DialogueBox2>(); // find object that script is in and get the script
        once = true;
        collected = false;

        ring = GetComponent<AudioSource>(); // get audio source component from object's inspector
    }

    private void OnTriggerEnter2D(Collider2D collision)  // if collision detect with coin
    {
        ring.Play();
        
        GetComponent<BoxCollider2D>().enabled = false; // disable coin's collider component
        GetComponent<SpriteRenderer>().enabled = false; // disable coin's sprite renderer component

        collected = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (value.puzzle == true && once) // if the variable in that script meets a condition
        {
            GetComponent<BoxCollider2D>().enabled = true; // disable coin's collider component
            GetComponent<SpriteRenderer>().enabled = true; // disable coin's sprite renderer component
            once = false;
        }
    }
}