using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTeleport : MonoBehaviour
{
    public DialogueBox value; // create value to reference another script
    public Transform location; // create field variable for object's transform component
    public SpriteRenderer flip; // create field variable for object's sprite renderer component

    void Awake()
    {
        value = GameObject.Find("Dialogue").GetComponent<DialogueBox>(); // find object that script is in and get the script
        location = GetComponent<Transform>(); // Get transform component of object
        flip = GetComponent<SpriteRenderer>(); // Get sprite renderer component of object
    }

    void Update()
    {
        if (value.teleport == true) // if variable is true after player collects key and talks to npc
        {
            location.transform.position = new Vector3 (-21.13f, -4.37f, -2.2319f); // change npc location to new dock
            flip.flipX = true; // flip direction of npc sprite
        }
    }
}
