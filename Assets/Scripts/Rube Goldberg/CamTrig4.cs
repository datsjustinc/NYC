using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrig4 : MonoBehaviour
{
    public GameObject mainCam;

    private void Awake() 
    { 
        mainCam = GameObject.FindWithTag("MainCamera"); //set the mainCam variable to the MainCamera 
    }   

    private void OnTriggerEnter2D(Collider2D collision) //check that the player has entered the trigger and not an enemy/other object
    { 
        if (collision.tag == "Ball") 
        { 
            mainCam.transform.position = new Vector3(-2.7f, -4.84f, mainCam.transform.position.z); //set the position of the camera to the current game objects position
            // mainCam.transform.rotation = transform.rotation;
        }
    } 

    private void OnTriggerExit2D(Collider2D collision) //check that the player has entered the trigger and not an enemy/other object
    { 
        if (collision.tag == "Ball") 
        { 
            mainCam.transform.position = new Vector3(-6.2f, -4.84f, mainCam.transform.position.z); //set the position of the camera to the current game objects position
            // mainCam.transform.rotation = transform.rotation;
        }
    } 
    
}