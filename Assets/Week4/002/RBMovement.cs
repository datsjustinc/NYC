using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBMovement : MonoBehaviour {

    private Rigidbody2D rb;

    [SerializeField]
    float jumpStength = 5.0f;
    float movementSpeed = 5.0f;
    float moveX;

    [SerializeField]
    bool isGrounded, canJump;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void PlayerControls() {

        if (Input.GetKeyDown(KeyCode.Space)) {
            canJump = true;
        }

        moveX = Input.GetAxis("Horizontal");
    }

    /// <summary>
    /// 
    /// </summary>
    void Jump() {
        if (!isGrounded)
            return;

        Debug.Log("Jump");
        rb.AddForce(Vector2.up * jumpStength, ForceMode2D.Impulse);
        isGrounded = false;

    }

    /// <summary>
    /// Let's me jump when I collide with something. Even if it's not a floor
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision) {

        isGrounded = true;
        Debug.Log(collision.gameObject.name, collision.gameObject);
    }

    private void FixedUpdate() {

        rb.velocity = new Vector2(moveX * movementSpeed, rb.velocity.y);

        if (canJump) {
            canJump = false;
            Jump();
        }



    }

    // Update is called once per frame
    void Update() {
        PlayerControls();
    }
}
