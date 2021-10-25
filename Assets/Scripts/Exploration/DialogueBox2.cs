using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox2 : MonoBehaviour
{

    public enum Stages {messageZero, messageOne, messageTwo, messageThree, messageFour, messageFive, messageSix, messageSeven, messageEight, messageNine, messageTen, messageEleven, messageTwelve, messageThirteen, messageFourteen} // store objects of type Stages
    public Stages myStage = Stages.messageOne; 


    public bool teleport; // used to move npc to another location

    public bool puzzle; // used to initiate puzzle 1 on land
    public TMP_Text dialogue; // create dialogue field variable

    public bool touching; // used to change dialogue to empty string

    public PlayerScore value; // create value to reference another script

    public DeactivateKey2 collect; // create value to reference another script

    public bool block; 

    AudioSource pop; // create new audio source variable
    //public GameObject npc; // create field variable to store game object



    //public int counter = 0;

    private void Awake()
    {
        dialogue = GetComponent<TMP_Text>();
        touching = false;
        puzzle = false;
        block = false;
        pop = GetComponent<AudioSource>(); // get audio source component from object's inspector
        value = GameObject.Find("Score").GetComponent<PlayerScore>(); // find object that script is in and get the script
        collect = GameObject.Find("Key").GetComponent<DeactivateKey2>(); // find object that script is in and get the script
        //npc = GameObject.FindWithTag("NPC"); // find object with specified tag and store in variable
    }

    void EnumChange()
    {

        switch (myStage)
        {
            case Stages.messageZero:
                pop.Play(); // play audio source
                dialogue.text = "Hi again!";
                myStage = Stages.messageOne;
                break;
            case Stages.messageOne:
                pop.Play(); // play audio source
                dialogue.text = "Welcome to the final map!";
                myStage = Stages.messageTwo;
                break;
            case Stages.messageTwo:
                pop.Play(); // play audio source
                dialogue.text = "If you can manage to survive this you can escape!";
                myStage = Stages.messageThree;
                break;
            case Stages.messageThree:
                pop.Play(); // play audio source
                dialogue.text = "First, climb up there and retrieve the key!";
                puzzle = true; // allow puzzle to appear
                break;
            case Stages.messageFour:
                pop.Play(); // play audio source
                dialogue.text = "Thanks, I'll take that.";
                myStage = Stages.messageFive;
                break;
            case Stages.messageFive:
                pop.Play(); // play audio source
                dialogue.text = "Alright, if you can get across, you win!";
                myStage = Stages.messageSix;
                break;
            case Stages.messageSix:
                pop.Play(); // play audio source
                dialogue.text = "Cya!";
                block = true;
                break;
             case Stages.messageSeven:
                pop.Play(); // play audio source
                dialogue.text = "You win!";
                break;
        }

        //counter++;
        //dialogue.text += " " + counter.ToString();
    }

    public void OnTriggerEnter2D(Collider2D collision) // method used to progress dialogue interaction only if player is touching npc
    { 
        touching = true; 
    }

    public void OnTriggerExit2D(Collider2D collision) // method used to stop dialogue interaction if player is away from npc
    {
        touching = false;
        dialogue.text = ""; // createa empty dialogue
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touching == true) // if key condition pressed
        {
            EnumChange(); // run method with switch case
        }

        if (collect.collected == true)
        {
            myStage = Stages.messageFour; // change message
            collect.collected = false; // set it back to false so the message does keep reiterating on messageEleven
        }

        if (value.pt == 9)
        {
            myStage = Stages.messageSeven; // change message
        }

        /*
         if (value.pt == 1) // if the variable in that script meets a condition
        {
            myStage = Stages.messageFour; // change message
            if ((Input.GetKeyDown(KeyCode.E) && touching == true)) // if key condition pressed
            {
                value.reset = true;
                puzzle = true; // allow puzzle to appear
            }
        }
        */
    }
}