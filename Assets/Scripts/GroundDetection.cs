using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    new public BoxCollider2D collider;
    public LayerMask ground;
    public bool isGroundedCheck;
    public Movement movement;
    public float rayNumber;
    Vector3 rayPosition;

    Vector3 max;
    Vector3 min;
    Vector3 size;
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
        Debug.Log(collider.bounds.size);
    }

    private bool Detection(){
        size = collider.bounds.size;
		min = collider.bounds.min;
		max = collider.bounds.max;

        for(int i = 0; i <  rayNumber; i++){
            rayPosition = new Vector3(max.x - (size.x / (rayNumber - 1)) * (i), min.y, 0);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, -Vector2.up, 0.08f, ground);
            Debug.DrawRay(rayPosition, Vector2.up * -0.14f, Color.red);
           
            if(hit.collider != null){
                Debug.Log("vc é gay");
                isGroundedCheck = true;
                movement.JumpResetTimer();
            }else{
                isGroundedCheck = false;
            }
        }
        return isGroundedCheck;
    }

    public bool isGrounded {
        get { return isGroundedCheck; }
    }
}
