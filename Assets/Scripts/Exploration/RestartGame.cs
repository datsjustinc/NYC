using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public string restartScene; // create field variable to store scene name

    public PlayerScore value; // create value to reference another script

    // Update is called once per frame

    void Awake()
    {
        value = GameObject.Find("Score").GetComponent<PlayerScore>(); // find object that script is in and get the script
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // if key pressed
        {
            SceneManager.LoadScene(restartScene); // load next scene
            value.reset = true;

        }
    }
}
