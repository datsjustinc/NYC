using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    Camera mainCamera;

    public bool on; // variable to control button click detection

    private void Awake()
    {
        mainCamera = Camera.main; // gets first camera that can be found with mainCamera tag
        on = false;
    }

    void ClickCheck()
    {
        if(Input.GetMouseButtonDown(0)) // 0 represents left mouse button click
        {
            // after left click, a ray will shoot out
            RaycastHit2D ray = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));

            if (ray.collider != null && ray.collider.CompareTag("ClickButton"))
            {
                on = true; // set button click to true
                ray.collider.GetComponent<LeverClick>().SelectButton(0);
                Debug.Log("Clicked!");
            }

        }

    }

    private void Update()
    {
        ClickCheck();
    }

}
