using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    public Vector3 position;
    MovementController movementController;
    Rigidbody2D rb;
    Transform character;
    void Start(){
        character = transform.parent;
        //movementController = transform.parent.gameObject.GetComponent<MovementController>();
        rb = character.gameObject.GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Ledge Box"){
            position = character.position;
            rb.velocity = new Vector3(rb.velocity.x, 0 ,0);
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.tag == "Ledge Box"){
            rb.velocity = new Vector3(rb.velocity.x, 0 ,0);
            character.position = position;
        }
    }
}
