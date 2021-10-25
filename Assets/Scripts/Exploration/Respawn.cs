using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject resp; // create field variable to store game object
    public GameObject spawn; // create field variable to store game object
    public GameObject boat; // create field variable to store game object
    //public string scene; // create field variable to store scene name

    AudioSource death; // create new audio source variable

    private void Awake() // use to initialize variables / game state before game starts
    { 
        resp = GameObject.FindWithTag("Respawn"); // find object with specified tag and store in variable
        spawn = GameObject.FindWithTag("Spawn"); // find object with specified tag and store in variable
        boat = GameObject.FindWithTag("Boat"); // find object with specified tag and store in variable

        death = GetComponent<AudioSource>(); // get audio source component from object's inspector
    }  

    private void OnTriggerEnter2D(Collider2D collision)  // collision detector
    {
        if (collision.CompareTag("Respawn")) // if current object collides with respawn object with specified tag
        {
            death.Play(); // play audio sound for death

            transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z); // set current object position to new spawn object position
            boat.transform.position = new Vector3(-14.783f, -5.75f, 0); // set new position for boat respawn
            //SceneManager.LoadScene(scene);
        }
        
    }
   
}
