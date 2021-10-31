using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject player; // create field variable to store spawn object
    public RBSimpleMove2 player1; // create value to reference another script
    public GameObject boat; // create field variable to store game object
    public Rigidbody2D stop; // create field variable to store object component

    AudioSource death; // create new audio source variable
    

    private void Awake() // use to initialize variables / game state before game starts
    { 
        player = GameObject.FindWithTag("Player"); // find object with specified tag and store in variable

        player1 = GameObject.Find("Player").GetComponent<RBSimpleMove2>(); // find object that script is in and get the script
        
        boat = GameObject.FindWithTag("Boat"); // find object with specified tag and store in variable
        
        stop = boat.GetComponent<Rigidbody2D>(); // get rigid body component of object

        death = GetComponent<AudioSource>(); // get audio source component from object's inspector
    }  

    private void OnTriggerEnter2D(Collider2D collision)  // collision detector
    {
        if (collision.CompareTag("Player")) // if current object collides with respawn object with specified tag
        {
            death.Play(); // play audio sound for death
            player1.control = true; // give player back control
            Destroy(player1.joint); // break join so player detached from boat
            player.transform.position = new Vector3(-19.70846f, -4.377595f, 0); // set current object position to new spawn object position
            boat.transform.position = new Vector3(-14.783f, -5.75f, 0); // set new position for boat respawn
            stop.velocity = Vector3.zero; // stop velocity of boat after player respawns
        }       
    }
    
}
