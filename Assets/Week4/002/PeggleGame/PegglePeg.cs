using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegglePeg : MonoBehaviour {

    public Color newColor = Color.white;

    //public PeggleScoreManager psm;

    private void Start() {
        //psm.otherPublicNumber += 1;
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        StartCoroutine(PegHitRoutine());

    }


    IEnumerator PegHitRoutine() {

        //PeggleScoreManager.score += 1;
        PeggleScoreManager.AddToScore();

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = newColor;
        yield return new WaitForSeconds(0.75f);
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
