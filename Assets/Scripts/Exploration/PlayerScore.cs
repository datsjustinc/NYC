using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour 
{

    public static int points; // create variable that can be accessed outside from another script
    public int pt = points; // create field variable to assign points to
    public TMP_Text displayScore; // create field variable to hold text

    public void Awake() // function called before game starts
    {
        displayScore = GetComponent<TMP_Text>(); // get text component and store in display score
    }

    // Update is called once per frame
    void Update() 
    {
        pt = points; // assign points to object's field variable
        displayScore.text = "Gold x " + pt.ToString(); // print text to screen
    }
}
