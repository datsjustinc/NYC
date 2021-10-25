using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public float minimum; // lowest position
    public float maximum; // highest position
 
    void Start () 
    {
        minimum = -4.34f; // set lowest position to object y value
        maximum = -3.0f; // set highest position to object y value plus the distance to move
    }
   
    // Update is called once per frame
    void Update () 
    {
        transform.Rotate(new Vector3(0, 0, 90 * Time.deltaTime * 10)); // rotate object

        transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time * 1.5f, maximum - minimum) + minimum, transform.position.z); // moves object up and down
    }
}
