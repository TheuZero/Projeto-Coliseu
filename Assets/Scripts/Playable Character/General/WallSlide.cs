using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    MovementController movementController;
    GroundDetection groundDetection;
    Rigidbody2D rb;
    Transform character;
    public bool isWallSliding;
    void Start(){
        character = transform.parent;
        groundDetection = character.gameObject.GetComponent<GroundDetection>();
        //movementController = transform.parent.gameObject.GetComponent<MovementController>();
        rb = character.gameObject.GetComponent<Rigidbody2D>();
        
    }
    void OnTriggerEnter2D(Collider2D col){
        if(!groundDetection.isGrounded){
            if(col.tag == "Ground"){
                rb.velocity = new Vector3(rb.velocity.x, 0 ,0);
                isWallSliding = true;
            }
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(!groundDetection.isGrounded){
            if(col.tag == "Ground"){
                rb.velocity = new Vector3(rb.velocity.x, 0 ,0);
                isWallSliding = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col){
        if(col.tag == "Ground"){
            isWallSliding = false;
        }
    }
}

