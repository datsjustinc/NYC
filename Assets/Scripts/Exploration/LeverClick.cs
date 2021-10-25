using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LeverClick : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Color green; 

    private void Awake()
    {
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
