using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float moveSpeed = 2f;

    float startPosition = 51.04f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        if(transform.position.x <= -12.76f){
            transform.position = new Vector2(startPosition, transform.position.y);
        }
    }
}
