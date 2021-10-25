using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public string restartScene; // create field variable to store scene name
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // if key pressed
        {
            SceneManager.LoadScene(restartScene); // load next scene
        }
    }
}
