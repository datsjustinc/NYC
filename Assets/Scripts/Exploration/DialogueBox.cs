using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{

    public enum Stages {messageZero, messageOne, messageTwo, messageThree, messageFour} // store objects of type Stages
    public Stages myStage = Stages.messageOne; 

    public bool goalComplete; // used to bring down barrier after completing goal
    public bool puzzle; // used to initiate puzzle 1 on land
    public bool teleport; // used to move npc to another location

    [SerializeField]

    public TMP_Text dialogue; // create dialogue field variable
    public bool introduction; // variable used later to display messageZero, restrict collision message to messageZero
    public bool once; // variable used to later display messageThree only once, so it can switch to messageFour
    public bool sign; // variable used later outside of script for last sprite/puzzle to trigger
    public PlayerScore value; // create value to reference another script
    public DeactivateKey collect; // create value to reference another script
    AudioSource pop; // create new audio source variable

    //public int counter = 0;

    private void Awake()
    {
        introduction = true;
        once = false;
        sign = false;
        puzzle = false;
        goalComplete = false;
        teleport = false;
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
                dialogue.text = "\nHi there!";
                myStage = Stages.messageOne;
                break;
            case Stages.messageOne:
                pop.Play(); // play audio source
                dialogue.text = "Find me a coin!";
                //myStage = Stages.messageTwo;
                break;

            case Stages.messageTwo:
                pop.Play(); // play audio source
                dialogue.text = "There's a key here somewhere..";
                //myStage = Stages.messageThree;
                break;

            case Stages.messageThree:
                pop.Play(); // play audio source
                dialogue.text = "Thanks! Meet me at the Docks.";
                once = true; // set variable false so the message wont be the same all the time after key collected
                //myStage = Stages.messageFour;
                break;
            case Stages.messageFour:
                pop.Play(); // play audio source
                dialogue.text = "Take a leap!";
                sign = true;
                teleport = true;
                //myStage = Stages.messageFour;
                break;
        }

        //counter++;
        //dialogue.text += " " + counter.ToString();
    }

    public void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (introduction) // if object(NPC) has not been introduced to player
        {
            EnumChange(); // run method and display first message
            introduction = false; // turn boolean off so that only first string will be collision triggered and not the other ones
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // if key condition pressed
        {
            EnumChange(); // run method with switch case
        }

        if (value.pt == 1) // if the variable in that script meets a condition
        {
            myStage = Stages.messageTwo; // change message

            if (Input.GetKeyDown(KeyCode.E)) // if key condition pressed
            {
                puzzle = true; // allow puzzle to appear
            }
        }

        if (collect.collected == true) // if the variable in that script meets a condition
        {
            myStage = Stages.messageThree; // change message
            goalComplete = true; // set variable to true which will allow barrier to be disabled
        }
        
        if (once) // if the variable in that script meets a condition
        {
            myStage = Stages.messageFour; // change message
        }
    }
}

