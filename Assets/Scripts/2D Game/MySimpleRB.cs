using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySimpleRB : MonoBehaviour
{
   Rigidbody2D rb;
   bool moveLeft;
   bool moveRight;
   public float power = 1.0f;

   private void Awake()
   {    
       rb = GetComponent<Rigidbody2D>();
   }

   void CheckInput()
   {
       if (Input.GetKeyDown(KeyCode.Space))
       {
       }

       if (Input.GetKey(KeyCode.LeftArrow))
       {
           moveLeft = true; 
       }
       else
       {
           moveLeft = false;
       }

       moveRight = Input.GetKey(KeyCode.RightArrow);
   }

   private void Update()
   {
       CheckInput();
   }

   private void FixedUpdate()
   {
        if (moveLeft)
            rb.AddForce(Vector2.left * power);

        if (moveRight)
            rb.AddForce(Vector2.right * power); 
      // rb.AddForce(new Vector2(-1.0f, 0.0f)); // This line is the same as before
   }
}
