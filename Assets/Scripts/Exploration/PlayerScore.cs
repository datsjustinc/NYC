using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour 
{
    Scene currentScene; // create variable to store scene
    string sceneName; // create variable to store scene name
    public static int points; // create variable that can be accessed outside from another script
    public int pt = points; // create field variable to assign points to
    public TMP_Text displayScore; // create field variable to hold text

    public bool reset; // used to reset score

    public void Awake() // function called before game starts
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        displayScore = GetComponent<TMP_Text>(); // get text component and store in display score

        pt = 0; // set player score to 0

        if (sceneName == "Little Island Exploration 2")
        {
            points = 4;
        }
        
        reset = false;
    }

    // Update is called once per frame
    void Update() 
    {
        if (reset == false)
        {
            pt = points; // assign points to object's field variable
            displayScore.text = "x" + pt.ToString(); // print text to screen
        }

        if (reset == true)
        {
            points = 0;
            displayScore.text = "x" + pt.ToString(); // print text to screen
            reset = false;
        }
    }
}
