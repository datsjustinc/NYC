using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDown : MonoBehaviour
{
    public DialogueBox value; // create value to reference another script
    private void Awake()
    {
        value = GameObject.Find("Dialogue").GetComponent<DialogueBox>(); // find object that script is in and get the script
    }

    private void Update()
    {
        if (value.goalComplete == true) // if player has collected key object and talked to npc
        {
            GetComponent<BoxCollider2D>().enabled = false; // disable TempBarrier's collider component
        }
    }
}

