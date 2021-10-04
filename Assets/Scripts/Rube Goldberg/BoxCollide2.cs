using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollide2 : MonoBehaviour {

    private BoxCollider2D bc;

    private void Awake() {
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }



    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Ball")) 
        {
            bc.isTrigger = false;
            collision.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            //collision.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
   
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
    
    }
}