using System.Collections.Generic;
using UnityEngine;

public class MyPeggleShooter : MonoBehaviour {

    public Rigidbody2D ball;
    Vector3 ballStartPosition;
    
    // Start is called before the first frame update
    void Start() {
        ballStartPosition = ball.transform.localPosition;
    }

    public void ResetBall() {

        ball.velocity = Vector2.zero;
        ball.angularVelocity = 0;
        ball.simulated = false;
        //ball.velocity = new Vector2(0, 0); // The longer version of the line of code above

        ball.transform.SetParent(transform, true);
        ball.transform.localPosition = ballStartPosition;
        ball.transform.localRotation = Quaternion.Euler(Vector3.zero);

    }

    // Update is called once per frame
    void Update() {

    }
}
