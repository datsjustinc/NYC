using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SimpleMove : MonoBehaviour
{
    public float speed = 2.5f; // Player Movement Speed

    // Start is called before the first frame update
    void Start()
    {

    }

    void MoveObject()
    {
        if (Input.GetKey(KeyCode.A)) // Left Movement
        {
            transform.Translate((Vector2.left * Time.deltaTime) * speed);
        }

        if (Input.GetKey(KeyCode.D)) // Right Movement
        {
            transform.Translate((Vector2.right * Time.deltaTime) * speed);
        }

        if (transform.position.x <= -8.5f) // Left Border
        {
            transform.position = new Vector2(-8.5f, transform.position.y);
        } 
        else if (transform.position.x >= 8.5f) // Right Border
        {
            transform.position = new Vector2(8.5f, transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }
}
