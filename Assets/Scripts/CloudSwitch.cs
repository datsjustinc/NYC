using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSwitch : MonoBehaviour
{
    public Animator animator;

    public bool on = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && on == false) // Right Movement
        { 
            animator.SetBool("Sign_Press", true);
            on = true;
        }
    
        else if (Input.GetKey(KeyCode.Space) && on == true) // Right Movement
        { 
            animator.SetBool("Sign_Press", false);
            on = false;
        }
    
    }
}
