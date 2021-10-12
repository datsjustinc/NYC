using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoatMove : MonoBehaviour
{
    public Rigidbody2D rb; // create field variable for object's rigid body component
    public float moveSpeed = 5.0f; // create and intialize object's move and jump values
    float moveX = 1.0f; // create value to store object's move direction


    public RBSimpleMove2 control; // create value to reference another script
    
    //public Rigidbody2D candy;
    //public Rigidbody2D otherCandy;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // get rigid body component of object
        //candy = otherCandy.GetComponent<Rigidbody2D>();

        control = GameObject.Find("Player").GetComponent<RBSimpleMove2>(); // find object that script is in and get the script
    }

    void PlayerControls()
    {
        moveX = Input.GetAxis("Horizontal"); // get movement input direction (-1, 1)
        //MOVEX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (!control.control)
        {
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y); // update object movement speed/direction
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!control.control)
        {
            PlayerControls(); // call player control function to run and detect movement always
        }
    }
}
