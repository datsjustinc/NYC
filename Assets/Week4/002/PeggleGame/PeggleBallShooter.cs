using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeggleBallShooter : MonoBehaviour {

    public Rigidbody2D ball;
    Vector3 ballStartPosition;
    Vector3 ballScale;


    // Start is called before the first frame update
    void Start() {

        ballStartPosition = ball.transform.localPosition;
        ballScale = ball.transform.localScale;
    }



    /// <summary>
    /// This will reset the ball back to it's original position
    /// </summary>
    public void ResetBall() {

        ball.velocity = Vector2.zero;
        ball.angularVelocity = 0;
        ball.simulated = false;

        ball.transform.SetParent(transform, true);
        ball.transform.localPosition = ballStartPosition;
        ball.transform.localRotation = Quaternion.Euler(Vector3.zero);
        ball.transform.localScale = ballScale;
    }


    // Update is called once per frame
    void Update() {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position); float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (Input.GetKey(KeyCode.LeftControl)) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
