using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPeggleBall : MonoBehaviour {

    Rigidbody2D rb;
    public float forceToAdd = 2.0f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    void MouseControls() {
        if (Input.GetMouseButtonDown(0)) {
            rb.simulated = true;
            transform.parent = null;
            rb.AddForce(transform.right * forceToAdd);
        }
    }

    // Update is called once per frame
    void Update() {
        MouseControls();
    }
}
