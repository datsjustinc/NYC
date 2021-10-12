using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PeggleScoreManager : MonoBehaviour {

    public static int score;
    public TMP_Text scoreText;
    
    //Testing and showing static vs private vs public
    public int otherPublicNumber;
    private int anotherNumber;

    public static void AddToScore() {
        score += 1;
    }

    private void Update() {
        scoreText.text = "score: " + score;
    }

}
