using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoatMove : MonoBehaviour
{
    public Rigidbody2D rb; // create field variable for object's rigid body component
    public float moveSpeed = 5.0f; // create and intialize object's move value
    float moveX = 1.0f; // create value to store object's move direction
    public Lever value; // create value to reference another script
    public RBSimpleMove2 player; // create value to reference another script
    
    //public Rigidbody2D candy;
    //public Rigidbody2D otherCandy;

    private void Awake()
    {
        GetComponent<BoxCollider2D>().enabled = false; // disable boat's collider component

        rb = GetComponent<Rigidbody2D>(); // get rigid body component of object
        //candy = otherCandy.GetComponent<Rigidbody2D>();

        player = GameObject.Find("Player").GetComponent<RBSimpleMove2>(); // find object that script is in and get the script

        value = GameObject.Find("Lever").GetComponent<Lever>(); // find object that script is in and get the script
    }

    void PlayerControls()
    {
        moveX = Input.GetAxis("Horizontal"); // get movement input direction (-1, 1)
        //MOVEX = Input.GetAxis("Horizontal");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DockComponent>()) // if collision with JumpComponent script attached to ground object
        {
            player.control = true; // if player has control back
            Destroy(player.joint); // break join so player detached from boat
        }
    }

    private void FixedUpdate()
    {
        if (!player.control)
        {
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y); // update object movement speed/direction
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.control)
        {
            PlayerControls(); // call player control function to run and detect movement always
        }

        if (value.on == true)
        {
            GetComponent<BoxCollider2D>().enabled = true; // disable boat's collider component
        }

        if (value.on == false)
        {
            GetComponent<BoxCollider2D>().enabled = false; // disable boat's collider component
        }

    }
}
