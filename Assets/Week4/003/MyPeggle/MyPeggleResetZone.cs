using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPeggleResetZone : MonoBehaviour {

    public MyPeggleBall mpb;
    public MyPeggleShooter mps;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.gameObject == mpb.gameObject) {
            mps.ResetBall();
        }

    }
}
