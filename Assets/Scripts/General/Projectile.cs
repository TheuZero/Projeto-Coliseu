﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 6;
    public float duration = 6f;
    public float side;
    public int maxHit;
    int hitCounter;

    AttackInfo attackInfo;
    GameObject player;
    
    void Awake(){
        attackInfo = new AttackInfo();
        player = transform.parent.transform.parent.transform.GetChild(0).gameObject;
    }
    void OnEnable(){
        StartCoroutine("Duration");
        attackInfo.side = player.transform.localScale.x;
        side = player.transform.localScale.x;
        hitCounter = maxHit;
    }

    void FixedUpdate(){
        transform.Translate(Vector2.right * (speed * side) * Time.deltaTime);
    }

/*  void SetAttack(){
        attackInfo.hitstun = 1;
        attackInfo.damage = 5;
        attackInfo.knockback = 8;
        attackInfo.knockbackDuration = 0.2f;
        attackInfo.knockup = 4.4f;
        attackInfo.knockupDuration = 0.10f;
    }*/

    IEnumerator Duration(){
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            hitCounter -= 1;
            if(hitCounter <= 0){
                gameObject.SetActive(false);
            }
        }
    }
}