using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{

    public enum Stages {messageZero, messageOne, messageTwo, messageThree, messageFour, messageFive, messageSix, messageSeven, messageEight, messageNine, messageTen} // store objects of type Stages
    public Stages myStage = Stages.messageOne; 

    public bool goalComplete; // used to bring down barrier after completing goal
    public bool puzzle; // used to initiate puzzle 1 on land
    public bool teleport; // used to move npc to another location
    public TMP_Text dialogue; // create dialogue field variable
    public bool sign; // variable used later outside of script for last sprite/puzzle to trigger
    public bool touching; // check to see if player is touching npc before dialogue appears
    public PlayerScore value; // create value to reference another script
    public DeactivateKey collect; // create value to reference another script
    AudioSource pop; // create new audio source variable

    //public int counter = 0;

    private void Awake()
    {
        sign = false;
        puzzle = false;
        goalComplete = false;
        teleport = false;
        touching = false;
        dialogue = GetComponent<TMP_Text>();
        value = GameObject.Find("Score").GetComponent<PlayerScore>(); // find object that script is in and get the script
        collect = GameObject.Find("Key").GetComponent<DeactivateKey>(); // find object that script is in and get the script
        pop = GetComponent<AudioSource>(); // get audio source component from object's inspector
    }

    void EnumChange()
    {

        switch (myStage)
        {
            case Stages.messageZero:
                pop.Play(); // play audio source
                dialogue.text = "Hi there!";
                myStage = Stages.messageOne;
                break;
            case Stages.messageOne:
                pop.Play(); // play audio source
                dialogue.text = "Welcome to the uncharted Isles of Oleas.";
                myStage = Stages.messageTwo;
                break;
            case Stages.messageTwo:
                pop.Play(); // play audio source
                dialogue.text = "You've been stranded here.";
                myStage = Stages.messageThree;
                break;
            case Stages.messageThree:
                pop.Play(); // play audio source
                dialogue.text = "In order to escape, you must completely explore the land.";
                myStage = Stages.messageFour;
                break;
            case Stages.messageFour:
                pop.Play(); // play audio source
                dialogue.text = "I've been assigned as your tour guide!";
                myStage = Stages.messageFive;
                break;
            case Stages.messageFive:
                pop.Play(); // play audio source
                dialogue.text = "Somewhere on this island are 3 gold coins.";
                myStage = Stages.messageSix;
                break;
            case Stages.messageSix:
                pop.Play(); // play audio source
                dialogue.text = "Find it and bring it to me.";
                //myStage = Stages.messageTwo;
                break;
            case Stages.messageSeven:
                pop.Play(); // play audio source
                dialogue.text = "I'll take that as payment, thanks!";
                myStage = Stages.messageEight;
                break;
            case Stages.messageEight:
                pop.Play(); // play audio source
                dialogue.text = "Now there's a key somewhere here.";
                myStage = Stages.messageNine;
                break;
            case Stages.messageNine:
                pop.Play(); // play audio source
                dialogue.text = "Find it and return to me.";
                //myStage = Stages.messageThree;
                break;
            case Stages.messageTen:
                pop.Play(); // play audio source
                dialogue.text = "Meet me at the Docks.";
                //myStage = Stages.messageFour;
                sign = true;
                teleport = true;
                break;
        }

        //counter++;
        //dialogue.text += " " + counter.ToString();
    }

    public void OnCollisionEnter2D(Collision2D collision) 
    { 
        touching = true; 
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touching == true) // if key condition pressed
        {
            EnumChange(); // run method with switch case
        }

        if (value.pt == 3) // if the variable in that script meets a condition
        {
            if (Input.GetKeyDown(KeyCode.E) && touching == true) // if key condition pressed
            {
                myStage = Stages.messageSeven; // change message
                value.reset = true;
                puzzle = true; // allow puzzle to appear
            }
        }

        if (collect.collected == true) // if the variable in that script meets a condition
        {
            myStage = Stages.messageTen; // change message
            goalComplete = true; // set variable to true which will allow barrier to be disabled
        }
        
    }
}

