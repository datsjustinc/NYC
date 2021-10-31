using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn2 : MonoBehaviour
{
    public GameObject resp; // create field variable to store game object
    public GameObject spawn; // create field variable to store game object
    public GameObject spawn2; // create field variable to store game object
    public GameObject spawn3; // create field variable to store game object
    public GameObject spawn4; // create field variable to store game object

    bool respawn;
    bool respawn2;
    bool respawn3;
    bool respawn4;

    public DeactivateKey2 collect; // create value to reference another script

    AudioSource death; // create new audio source variable

    private void Awake() // use to initialize variables / game state before game starts
    { 
        resp = GameObject.FindWithTag("Respawn"); // find object with specified tag and store in variable
        spawn = GameObject.FindWithTag("Spawn"); // find object with specified tag and store in variable
        spawn2 = GameObject.FindWithTag("Spawn2"); // find object with specified tag and store in variable
        spawn3 = GameObject.FindWithTag("Spawn3"); // find object with specified tag and store in variable
        spawn4 = GameObject.FindWithTag("Spawn4"); // find object with specified tag and store in variable

        respawn = false;
        respawn2 = false;
        respawn3 = false;
        respawn4 = false;

        death = GetComponent<AudioSource>(); // get audio source component from object's inspector

        collect = GameObject.Find("Key").GetComponent<DeactivateKey2>(); // find object that script is in and get the script
    }  

    private void OnTriggerEnter2D(Collider2D collision)  // collision detector
    {
        if (collect.collected == true)
        {
            respawn4 = false;
        }
        
        if (collision.CompareTag("Respawn") || collision.CompareTag("Enemy")) // if current object collides with respawn object with specified tag
        {
            respawn = true;
        }

        else if (collision.CompareTag("Spawn4"))
        {
            respawn4 = true;
        }

        else if (collision.CompareTag("Spawn2")) // if current object collides with respawn object with specified tag
        {
            respawn2 = true;
            respawn = false;
            respawn4 = false;
        }

        else if (collision.CompareTag("Spawn3")) // if current object collides with respawn object with specified tag
        {
            respawn3 = true;
            respawn = false;
            respawn2 = false;
            respawn4 = false;
        }

        if (respawn == true)
        {
            death.Play(); // play audio sound for death
            transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y + 1, spawn.transform.position.z); // set current object position to new spawn object position
            respawn = false;
            respawn4 = false;
        }

        if (respawn4 == true && collision.CompareTag("Dock2"))
        {
            death.Play(); // play audio sound for death
            transform.position = new Vector3(spawn4.transform.position.x, spawn4.transform.position.y, spawn4.transform.position.z); // set current object position to new spawn object position
        }

        if (respawn2 == true && collision.CompareTag("Enemy"))
        {
            death.Play(); // play audio sound for death
            transform.position = new Vector3(spawn2.transform.position.x, spawn2.transform.position.y, spawn2.transform.position.z); // set current object position to new spawn object position
        }

        if (respawn3 == true && collision.CompareTag("Enemy"))
        {
            death.Play(); // play audio sound for death
            transform.position = new Vector3(spawn3.transform.position.x, spawn3.transform.position.y , spawn3.transform.position.z); // set current object position to new spawn object position
        }
        
    }
   
}
