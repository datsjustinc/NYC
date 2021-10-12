using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{

    public enum Stages {messageZero, messageOne, messageTwo, messageThree}
    public Stages myStage = Stages.messageOne;

    [SerializeField]

    public TMP_Text dialogue;
    public bool introduction;

    public PlayerScore value;

    //public int counter = 0;

    private void Awake()
    {
        introduction = true;
        dialogue = GetComponent<TMP_Text>();
        value = GameObject.Find("Score").GetComponent<PlayerScore>();

    }

    void EnumChange()
    {

        switch (myStage)
        {
            case Stages.messageZero:
                dialogue.text = "\nPress 'e'!";
                myStage = Stages.messageOne;
                break;
            case Stages.messageOne:
                dialogue.text = "Find all the coins!";
                //myStage = Stages.messageTwo;
                break;

            case Stages.messageTwo:
                dialogue.text = "I lost a key here!";
                //myStage = Stages.messageThree;
                break;

            case Stages.messageThree:
                dialogue.text = "Find my boat!";
                //myStage = Stages.messageThree;
                break;
        }

        //counter++;
        //dialogue.text += " " + counter.ToString();
    }

    public void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (introduction)
        {
            EnumChange();
            introduction = false;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnumChange();
        }

        if (value.pt == 11)
        {
            myStage = Stages.messageTwo;
        }
    }
}

