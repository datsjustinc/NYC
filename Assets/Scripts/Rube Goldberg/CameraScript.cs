using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // method runs on a fixed number of frames, runs same amount of time no matter how fast or slow compute ris
    void FixedUpdate()
    {
        transform.position = new Vector3(-6.20f, -0.83f, transform.position.z);
    }

}
