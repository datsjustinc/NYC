using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    private BoxCollider2D bc;

    private void Awake() {
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
    }



    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Ball")) {
            bc.isTrigger = false;
            collision.GetComponent<Rigidbody2D>().gravityScale = 0.98f;
        }
        
        Debug.Log("A collision has happened!!", gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Debug.Log("A collision has happened again!!!");
    }

    private void OnTriggerStay2D(Collider2D collision) {
        
    }
}