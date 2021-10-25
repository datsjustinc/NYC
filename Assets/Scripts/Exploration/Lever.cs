using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    Camera mainCamera;
    public bool touching; 

    public Animator animator; 

    public int condition; // used for switch on and off

    public bool on; // variable to control button click detection

    AudioSource lever; // create new audio source variable

    private void Awake()
    {
        mainCamera = Camera.main; // gets first camera that can be found with mainCamera tag
        on = false;
        touching = false;
        condition = -1; // -1 for off, 1 for on
        lever = GetComponent<AudioSource>(); // get audio source component from object's inspector
    }

    private void OnTriggerEnter2D(Collider2D collision)  // if collision detect with coin
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("True");
            touching = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  // if collision detect with coin
    {
        if (collision.CompareTag("Player"))
        {
            touching = false; 
        }
    }
    void ClickCheck()
    {
        if (touching == true) // if player is touching lever
        {
            if(Input.GetKeyDown(KeyCode.E)) // 0 represents left mouse button click
            {
                condition *= -1;
                lever.Play(); // play audio sound for lever
                animator.SetInteger("On", condition); // set lever animation

                if (condition == -1)
                {
                    on = false; // set button click to true
                }

                if (condition == 1)
                {
                    on = true; // set button click to true
                }
            }
        }

        /*
        if(Input.GetMouseButtonDown(0)) // 0 represents left mouse button click
        {
            if (touching == true)
            {
            // after left click, a ray will shoot out
                RaycastHit2D ray = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));

                if (ray.collider != null && ray.collider.CompareTag("Lever"))
                {
                    on = true; // set button click to true
                    //ray.collider.GetComponent<LeverClick>().SelectButton(0);
                }
            }
        }
        */

    }

    private void Update()
    {
        ClickCheck();
    }

}
