﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpecialBehaviour : MonoBehaviour
{
    Status status;

    float timer;
    float movementSpeed = 7f;
    float direction;
    float xSpeed;
    float ySpeed;
    AttackDetection attackDetection;
    public AttackData[] attackList = new AttackData[0];
    AttackData attackData;
    MovementData movementData;
    Vector2 orientation;    
    //temporary
    Animator anim;
    void Start()
    {
        status = GetComponent<Status>();
        attackDetection = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<AttackDetection>();
        //temp
        anim = GetComponent<Animator>();
    }

    void Update(){
        if(Input.GetKeyDown("q")){
            anim.SetTrigger("SpecialDash");
        }
    }
    public IEnumerator DashSpecialAttack(int index){
        AssignMovement(index);
        timer = 0.3f;
        GetDirection();
        while(timer > 0){
            timer -= Time.deltaTime;
            MoveCharacter();
            yield return null;
        }
        yield break;
    }
    void AssignMovement(int index){
        xSpeed = attackData.movementData.moveData[index].XSpeed;
        ySpeed = attackData.movementData.moveData[index].YSpeed;
        orientation = new Vector2(attackData.movementData.moveData[index].XOrientation, attackData.movementData.moveData[index].YOrientation);
    }
    void GetDirection(){
        direction = Mathf.Sign(transform.localScale.x);
    }
        
    void MoveCharacter(){
        transform.Translate(Vector2.right * xSpeed * Time.deltaTime * direction * orientation.x);
        transform.Translate(Vector2.up * ySpeed * Time.deltaTime * orientation.y);
    }

    //invocado na animação, já que é impossivel invocar métodos de scripts de outros objetos.
    void SetAttack(int index){
        attackDetection.AttackSideOrigin(transform.localScale.x);
        attackData = attackList[0];
        attackDetection.DamageInsert(attackData);
        attackDetection.SetAttack(index);
    }

    /*public IEnumerator DashSpecialAttack(){
        timer = 0.3f;
        GetDirection();
        while(timer > 0){
            timer -= Time.deltaTime;
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime * direction);
            yield return null;
        }
        yield break;
    }*/

}

