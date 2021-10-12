using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBSimpleMove2 : MonoBehaviour
{
    public Rigidbody2D rb; // create field variable for object's rigid body component
    public float moveSpeed, jumpPower = 5.0f; // create and intialize object's move and jump values
    [SerializeField]
    bool isGrounded; // create boolean to detect object's contact with ground object
    [SerializeField]
    bool canJump = true; // create control variable for object's jump
    float moveX = 1.0f; // create value to store object's move direction

    public Animator animator;
    
    //public Rigidbody2D candy;
    //public Rigidbody2D otherCandy;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // get rigid body component of object
        //candy = otherCandy.GetComponent<Rigidbody2D>();
    }

    void PlayerControls()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // if key pressed
        {
            canJump = true; // set jump boolean to true
        }

        moveX = Input.GetAxis("Horizontal"); // get movement input direction (-1, 1)
        //MOVEX = Input.GetAxis("Horizontal");
        
    } 
    void Jump()
    {
        if (!isGrounded) // if object is still in air
        {
            return; // do not excecute rest of jump function and return nothing
        }

        animator.SetBool("Jump", true); // trigger object's jump animation
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); // make object jump
        isGrounded = false; // set boolean to false after object leaves ground
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.GetComponent<JumpComponent>()) // if collision with JumpComponent script attached to ground object
        {
            isGrounded = true; // set ground variable to true
            animator.SetBool("Jump", false); // stop object's jump animation
        }
    
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y); // update object movement speed/direction

        animator.SetFloat("Speed", Mathf.Abs(moveX * moveSpeed)); // trigger object's run animation

        if (canJump)
        {
            canJump = false; // set this boolean to false so it can be triggered again 
            Jump(); // call jump function to execute
        } 
    }





    // Update is called once per frame
    void Update()
    {
        PlayerControls(); // call player control function to run and detect movement always
    }
}
