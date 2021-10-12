using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPegglePeg : MonoBehaviour {

    public Color newColor = Color.green;

    public void OnCollisionEnter2D(Collision2D collision) {

        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        MyPeggleGM.points += 1;
        //GetComponent<SpriteRenderer>().color = newColor;

    }
}
