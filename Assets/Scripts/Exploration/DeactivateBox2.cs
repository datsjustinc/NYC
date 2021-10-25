using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateBox2 : MonoBehaviour
{
    public DialogueBox2 value; // create value to reference another script
    void Awake()
    {
        GetComponent<CircleCollider2D>().enabled = false; // disable coin's collider component
        GetComponent<SpriteRenderer>().enabled = false; // disable coin's sprite renderer component
        //GetComponent<Rigidbody2D>().gravityScale = 0f; // disable coin's rigidbody gravity component

        value = GameObject.Find("Dialogue").GetComponent<DialogueBox2>(); // find object that script is in and get the script
    }

    // Update is called once per frame
    void Update()
    {
        if (value.puzzle == true) // if the variable in that script meets a condition
        {
            GetComponent<CircleCollider2D>().enabled = true; // disable coin's collider component
            GetComponent<SpriteRenderer>().enabled = true; // disable coin's sprite renderer component
            //GetComponent<Rigidbody2D>().gravityScale = 5f; // adjust coin's rigidbody gravity component
        }
    }
}
