using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSign : MonoBehaviour
{
    public DialogueBox sign; // create value to reference another script
    
    void Awake()
    {
        GetComponent<SpriteRenderer>().enabled = false; // disable coin's sprite renderer component

        sign = GameObject.Find("Dialogue").GetComponent<DialogueBox>(); // find object that script is in and get the script
    }


    // Update is called once per frame
    void Update()
    {
        if (sign.sign) // if the variable in that script meets a condition
        {
            GetComponent<SpriteRenderer>().enabled = true; // disable coin's sprite renderer component
        }
    }
}