using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour 
{
    //public Rigidbody2D body;

    private void Awake() 
    {
      Time.timeScale = 0;
      /*
      body = gameObject.GetComponent<Rigidbody2D>();
      */
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 1;
        } 
        /*
        if (Input.GetKey(KeyCode.Space))
        {
            body.bodyType = RigidbodyType2D.Dynamic;
        } 
        */
    }
}
