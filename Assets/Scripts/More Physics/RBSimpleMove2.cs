using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBSimpleMove2 : MonoBehaviour
{
    public Rigidbody2D rb; // create field variable for object's rigid body component
    public float moveSpeed, jumpPower = 3.0f; // create and intialize object's move and jump values
    [SerializeField]
    bool isGrounded; // create boolean to detect object's contact with ground object
    [SerializeField]
    bool canJump = true; // create control variable for object's jump
    float moveX = 1.0f; // create value to store object's move direction

    public Animator animator;
    public Joint2D joint; // create value to store joint component

    public SpriteRenderer flip; // create field variable for object's sprite renderer component

    public TrailRenderer trail; // create field variable for object's sprite renderer component

    public Color alpha; // create field variable for object's sprite renderer color component

    bool onBoat; // create variable to detect if player is on the boat object

    public bool control; // determine whether player can move or boat can move
    
    //public Rigidbody2D candy;
    //public Rigidbody2D otherCandy;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // get rigid body component of object
        //candy = otherCandy.GetComponent<Rigidbody2D>();
        control = true; // player starts with control of movement first intialize
        onBoat = false; // player is not on boat intialize
        flip = GetComponent<SpriteRenderer>(); // Get sprite renderer component of object
        trail = GetComponent<TrailRenderer>(); // get trail renderer component of object
        alpha.a = 0.8f; // set color that will be assigned to sprite renderer component of object
        trail.emitting = false; // set property of trail renderer component to false
    }

    void PlayerControls()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // if key pressed
        {
            if (control)
            {
                canJump = true; // set jump boolean to true
            }
        }

        if (Input.GetKey(KeyCode.LeftShift)) // if button pressed
        {
            animator.speed = 1.5f; // speed up animation frames when sprinting
            moveSpeed = 3.5f; // player speed increases (sprint)
            trail.emitting = true; // set property of trail renderer component to false
            //trail.startColor = alpha; 
        }

        else
        {
            animator.speed = 1; // default animation frame speed
            moveSpeed = 2.5f; // else goes back to regular speed
            trail.emitting = false; // set property of trail renderer component to false
        }

        moveX = Input.GetAxis("Horizontal"); // get movement input direction (-1, 1)
        //MOVEX = Input.GetAxis("Horizontal");

        if (moveX < 0) // if movement in negative direction
        {
            flip.flipX = true; // flip sprite to left direction
        }

        else if (moveX > 0) // if movement in positive direction
        {
            flip.flipX = false; // flip sprite to right direction
        }
        
    } 
    void Jump()
    {
        if (!isGrounded) // if object is still in air
        {
            return; // do not excecute rest of jump function and return nothing
        }

        animator.SetBool("Jump", true); // trigger object's jump animation
        //flip.color = alpha; // change player alpha color
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); // make object jump
        isGrounded = false; // set boolean to false after object leaves ground
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.GetComponent<JumpComponent>()) // if collision with JumpComponent script attached to ground object
        {
            isGrounded = true; // set ground variable to true
            animator.SetBool("Jump", false); // stop object's jump animation

            if (collision.gameObject.GetComponent<BoatComponent>()) // if collision with BoatComponent script attached to ground object
            {
                if (!onBoat) // if on boat
                {
                    joint = gameObject.AddComponent<FixedJoint2D>(); // create new fixed joint component on player
                    joint.connectedBody = collision.rigidbody; // attach joint to collision object, which is boat
                    onBoat = true; // indicator set to true tha player is on boat
                    control = false; // player loses control 
                }
            }
            
            else
            {
                onBoat = false; 
            }
        }
    }

    /*
    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.GetComponent<JumpComponent>()) // if collision with JumpComponent script attached to ground object
            {
                control = true;
            }
    }
    */

    private void FixedUpdate()
    {
        if (control)
        {
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y); // update object movement speed/direction
        }

        //animator.SetFloat("Speed", Mathf.Abs(moveX * moveSpeed)); // trigger object's run animation

        if (canJump)
        {
            canJump = false; // set this boolean to false so it can be triggered again 
            Jump(); // call jump function to execute
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (control)
        {
            animator.SetFloat("Speed", Mathf.Abs(moveX * moveSpeed)); // set animation back to walk
            PlayerControls(); // call player control function to run and detect movement always
            //GetComponent<Rigidbody2D>().mass = 1; // disable coin's sprite renderer component
        }

        else if (!control)
        {
            animator.SetFloat("Speed", 0); // set animation back to idle
            //GetComponent<Rigidbody2D>().mass = 1; // disable coin's sprite renderer component
        }
    }
}
