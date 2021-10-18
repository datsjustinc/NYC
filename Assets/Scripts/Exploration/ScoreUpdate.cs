using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour 
{

    public Color newColor = Color.green; // create new field variable and initialize to the color green

    AudioSource coin; // create new audio source variable
    
    void Start()
    {
        coin = GetComponent<AudioSource>(); // get audio source component from object's inspector
      
    }

    private void OnTriggerEnter2D(Collider2D collision)  // if collision detect with coin
    {
        coin.Play(); // play audio source
        GetComponent<Collider2D>().enabled = false; // disable coin's collider component
        GetComponent<SpriteRenderer>().enabled = false; // disable coin's sprite renderer component
        PlayerScore.points += 1; // access
        //GetComponent<SpriteRenderer>().color = newColor;
    }
}