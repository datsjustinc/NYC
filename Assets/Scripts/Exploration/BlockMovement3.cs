using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement3 : MonoBehaviour
{
    public float minimum; // lowest position
    public float maximum; // highest position
 
    void Start() 
    {
        minimum = 6.85f; // set lowest position to object y value
        maximum = 8.85f; // set highest position to object y value plus the distance to move
    }
   
    // Update is called once per frame
    void Update() 
    {
        transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime * 10)); // rotate object

        transform.position = new Vector3(Mathf.PingPong(Time.time * 1.5f, maximum - minimum) + minimum, transform.position.y, transform.position.z); // moves object up and down
    }
}

