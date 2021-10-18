using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public string nextScene; // create field variable to store scene name

    private void OnTriggerEnter2D(Collider2D collision) // if collision is triggered by an object
    {
        if (collision.CompareTag("Player")) // and if this object has the player tag
        {
            SceneManager.LoadScene(nextScene); // load next scene
        }
    }
}
