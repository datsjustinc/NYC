using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2f, 2f), Mathf.Clamp(transform.position.y, -8.5f, 8.5f), Mathf.Clamp(transform.position.z, -8.5f, 8.5f));
         
    }
}
