using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBSimpleMove : MonoBehaviour {

    public Rigidbody2D rb;
    public float moveSpeed, jumpPower = 5.0f;

    [SerializeField]
    bool isGrounded;
    [SerializeField]
    bool canJump = true;
    float moveX = 1.0f;

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
    /// This is the jump function
    /// </summary>
    void Jump() {

        if (!isGrounded)
            return;

        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        isGrounded = false;
        Debug.Log("JUMP!!!");

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.GetComponent<MyJumpComponent>()) {
            isGrounded = true;
            Debug.Log(collision.gameObject.name, collision.gameObject);
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

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
