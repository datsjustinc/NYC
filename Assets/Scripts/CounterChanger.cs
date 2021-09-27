using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterChanger : MonoBehaviour
{

    public enum Stages {Increase, Decrease}
    public Stages myStage = Stages.Increase;

    public TMP_Text counterText;
    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void EnumChange()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(myStage)
            {
                case Stages.Increase:
                    counter++;
                    break;
                
                case Stages.Decrease:
                counter--;
                    break;
            }
            //counterText.text = $"{counter}";
            counterText.text = counter.ToString();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            switch (myStage)
            {
                case Stages.Increase:
                    myStage = Stages.Decrease;
                    break;
                
                case Stages.Decrease:
                    myStage = Stages.Increase;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnumChange(); 
    }
}
