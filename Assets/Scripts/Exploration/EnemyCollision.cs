using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject player; // create field variable to store spawn object
    public GameObject boat; // create field variable to store game object

    private void Awake() // use to initialize variables / game state before game starts
    { 
        player = GameObject.FindWithTag("Player"); // find object with specified tag and store in variable
        boat = GameObject.FindWithTag("Boat"); // find object with specified tag and store in variable
    }  

    private void OnTriggerEnter2D(Collider2D collision)  // collision detector
    {
        if (collision.CompareTag("Player")) // if current object collides with respawn object with specified tag
        {
            player.transform.position = new Vector3(-19.70846f, -4.377595f, 0); // set current object position to new spawn object position
            boat.transform.position = new Vector3(-14.783f, -5.75f, 0); // set new position for boat respawn
        }
        
    }
}
