using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject resp; // create field variable to store game object
    public GameObject spawn; // create field variable to store game object

    private void Awake() // use to initialize variables / game state before game starts
    { 
        resp = GameObject.FindWithTag("Respawn"); // find object with specified tag and store in variable
        spawn = GameObject.FindWithTag("Spawn"); // find object with specified tag and store in variable
    }  

    private void OnTriggerEnter2D(Collider2D collision)  // collision detector
    {
        if (collision.CompareTag("Respawn")) // if current object collides with respawn object with specified tag
        {
            transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z); // set current object position to new spawn object position
        }
        
    }
   
}
