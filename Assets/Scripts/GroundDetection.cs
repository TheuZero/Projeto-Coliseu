using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public BoxCollider2D collider;
    public LayerMask ground;
    public bool isGrounded;
    public Movement movement;


    void Start()
    {
        movement = GetComponent<Movement>();
        collider = GetComponent<BoxCollider2D>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Detection();
        //Debug.Log(collider.bounds.min);
       // Debug.Log(Vector2.up * -0.014f);
    }

    public void Detection(){
        RaycastHit2D hit = Physics2D.Raycast(collider.bounds.min, -Vector2.up, 0.14f, ground);
        Debug.DrawRay(collider.bounds.min, Vector2.up * -0.14f, Color.red);
        
        if(hit.collider != null){
            Debug.Log("vc é gay");
            isGrounded = true;
            movement.ResetTimer(0f);
        }
    }
}
