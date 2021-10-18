using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyCameraRaycast : MonoBehaviour
{
    Camera mainCamera;
    public TMP_Text myText;
    int points = 0;

    private void Awake()
    {
        mainCamera = Camera.main; // gets first camera that can be found with mainCamera tag
    }

    void ClickCheck()
    {
        if(Input.GetMouseButtonDown(0)) // 0 represents left mouse button click
        {
            // after left click, a ray will shoot out
            RaycastHit2D ray = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));

            if (ray.collider != null && ray.collider.CompareTag("ClickButton"))
            {
                ray.collider.GetComponent<MyCircleClick>().SelectButton(0);
            }

            points += 1;
            myText.text = "Points: " + points;

        }

        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Input.mousePosition));

            if (ray.collider != null && ray.collider.CompareTag("ClickButton"))
            {
                ray.collider.GetComponent<MyCircleClick>().SelectButton(1);
            }

            points -= 1;
            myText.text = "Points: " + points;

        }
    }

    private void Update()
    {
        ClickCheck();
    }

}
