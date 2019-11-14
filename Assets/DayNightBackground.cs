using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightBackground : MonoBehaviour
{
    SpriteRenderer image;
    float currentColor;
    float currentTime;
    public Color color;
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {

        currentTime += Time.deltaTime/300;
        currentColor = Mathf.PingPong(10 * currentTime, 0.5f);
        image.color = new Color(0.87f - currentColor,0.87f - currentColor,0.87f - currentColor,1f);
    }
}
