using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivalScreenMove : MonoBehaviour
{
    float moveSpeed = 0.1f;
    Renderer render;
    void Start()
    {
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        render.material.mainTextureOffset = new Vector2(Time.time * moveSpeed,0);
    }
}
