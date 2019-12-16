using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    float moveTimer = 0;
    float defaultmoveTimer = 1f;
    float idleTimer = 1f;
    float defaultIdleTimer = 1f;
    float lastDirection;

    public GameObject player;
    public MovementController moveController;

    public GameObject alertBox;
    public GameObject patrolBox;

    void Awake()
    {
        player = transform.GetChild(0).gameObject;
        moveController = player.GetComponent<MovementController>();
        lastDirection = player.transform.localScale.x;
    }

    void FixedUpdate()
    {
        if(moveTimer > 0){
            moveTimer -= Time.deltaTime;
            Walk();
        }else{
            moveController.CancelWalk();
            Idle();
        }
    }

    void Walk(){
        if(lastDirection >= 1){
            moveController.WalkRight();
        }else{
            moveController.WalkLeft();
        }
    }
    void Idle(){
        if(idleTimer > 0){
            idleTimer -= Time.deltaTime;
        }else if(idleTimer <= 0){
            moveTimer = defaultmoveTimer;
            idleTimer = defaultIdleTimer;
            lastDirection = -lastDirection;
        }
    }

    public void AlertMode(){
        patrolBox.SetActive(false);
        alertBox.SetActive(true);
        
        this.enabled = false;
    }



}
