using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision2 : MonoBehaviour
{
    public GameObject player; // create field variable to store spawn object
    public GameObject spawn; // create field variable to store game object

    
    AudioSource death; // create new audio source variable

    private void Awake() // use to initialize variables / game state before game starts
    { 
        player = GameObject.FindWithTag("Player"); // find object with specified tag and store in variable
        spawn = GameObject.FindWithTag("Spawn"); // find object with specified tag and store in variable

        death = GetComponent<AudioSource>(); // get audio source component from object's inspector
    }  

    /*
    private void OnTriggerEnter2D(Collider2D collision)  // collision detector
    {
        if (collision.CompareTag("Player")) // if current object collides with respawn object with specified tag
        {
            death.Play(); // play audio sound for death
            player.transform.position = new Vector3(spawn.transform.position.x + 1, spawn.transform.position.y + 1, spawn.transform.position.z); // set current object position to new spawn object position); // set current object position to new spawn object position
        }
        
    }
    */
}
