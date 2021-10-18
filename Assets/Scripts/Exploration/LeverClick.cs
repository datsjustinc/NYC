using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeverClick : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Color green; 

    private void Awake()
    {
        green = new Color(63f, 188f, 79f, 255f);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SelectButton(int n)
    {
        if (n == 0)
        {
            spriteRenderer.color = green;
        }
    }

}
