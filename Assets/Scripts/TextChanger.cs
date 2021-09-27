using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextChanger : MonoBehaviour
{

    public enum Stages {StageOne, StageTwo, StageThree}
    public Stages myStage = Stages.StageOne;

    [SerializeField]

    public TMP_Text myText;
    public string newText = "This is New Text!?";

    public int counter = 0;

    private void Awake()
    {
        myText = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //myText.text = "This is Some Text!!!!";
        myText.text = newText;
    }

    void EnumChange()
    {

        switch (myStage)
        {
            case Stages.StageOne:
                myText.text = "Stage One!!";
                myStage = Stages.StageTwo;
                break;

            case Stages.StageTwo:
                myText.text = "Stage Two!!";
                myStage = Stages.StageThree;
                break;

            case Stages.StageThree:
                myText.text = "Stage Three!!";
                myStage = Stages.StageOne;
                break;
        }

        counter++;
        myText.text += " " + counter.ToString();

        /*
        if (myStage == Stages.StageOne)
        {
            myText.text = "Stage One!!";
            myStage = Stages.StageTwo;
        }
        else if (myStage == Stages.StageTwo)
        {
            myText.text = "Stage Two!!";
            myStage = Stages.StageThree;
        }
        else if (myStage == Stages.StageThree)
        {
            myText.text = "Stage Three!!";
            myStage = Stages.StageOne;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            EnumChange();
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            myText.text = "I pressed space!";
        }
    }
}
