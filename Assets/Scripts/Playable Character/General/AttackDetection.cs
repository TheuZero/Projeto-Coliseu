﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AttackDetection : MonoBehaviour
{
    GameModeManager gameMode;
    public GameObject player;
    Attack attackClass;
    Animator anim;
    public AttackInfo attackInfo;
    Status status;
    AttackData attackData;
    HitData[] hitData;
    public float attackModifier;
    public float attack;
    List<MonoBehaviour> subjects = new List<MonoBehaviour>();

    public ParticleSystem hitEffect;
    public int effectIndex = 0;

    void Start(){
        if(player == null){
            player = transform.parent.transform.parent.transform.parent.gameObject;
        }
        //attackClass = player.GetComponent<Attack>();
        try{
            gameMode = GameObject.Find("Game Mode Manager").GetComponent<GameModeManager>();
        }catch(Exception e){
            Debug.Log("Gamemode não encontrado, debug");
        }
        anim = player.GetComponent<Animator>();
        status = player.GetComponent<Status>();
        attackInfo = new AttackInfo();

        //adicionar play e stop junto com set de posição no objeto de feito
        hitEffect = player.transform.parent.transform.GetChild(2).GetChild(effectIndex).GetComponent<ParticleSystem>();

        SubscribeOnHit();
    }

    void SubscribeOnHit(){
        subjects.Add(player.GetComponent<FreezeSpecialBehaviour>());
    }
    void OnHitNotify(){
        foreach(MonoBehaviour m in subjects){
           // m.OnHit();
        }
    }

    void DamageCalc(){
       
    }

    public void AttackSideOrigin(float side){
        attackInfo.side = Mathf.Sign(side);
    }
    //invocado pela animação
    public void SetAttack(AttackData attackData, int hitData){
        this.attackData = attackData;
        attackInfo.damage = attackData.hitData[hitData].DmgMultiplier;
        attackInfo.knockback = attackData.hitData[hitData].Knockback;
        attackInfo.knockup = attackData.hitData[hitData].Knockup;
        attackInfo.hitstun = attackData.hitData[hitData].Hitstun;
        attackInfo.hitlag = attackData.hitData[hitData].Hitlag;
        Debug.Log("AAAAAAAAAAAAAAA O ATAQUE É DE: " + attackInfo.damage);
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if(col == null){
            Debug.Log("wtf");
        }
        if(CanHit(col)){
            AttackSideOrigin(Mathf.Sign(player.transform.localScale.x));
            col.gameObject.GetComponent<DamageDetection>().TakeDamage(attackInfo);
            StartCoroutine(status.FreezeCharacter(attackInfo.hitlag));
            hitEffect.transform.position = new Vector3(col.transform.position.x, col.transform.position.y, 0);
            if(Mathf.Sign(player.transform.localScale.x) == 1){
                hitEffect.transform.eulerAngles = new Vector3(0,0,0);
            }else{
                hitEffect.transform.eulerAngles = new Vector3(0,180,0);
            }
            hitEffect.Stop();
            hitEffect.Play();
        }
        
    }

    bool CanHit(Collider2D col){
        if(col.gameObject.tag == "Hurt Box" && gameObject.tag != "Hit Box (Enemy)"){
            return true;
        }
        if(col.gameObject.tag == "Hurt Box (Player)" && gameMode.currentGameMode == GameModeManager.GameMode.PVP){
            return true;
        }
        if(col.gameObject.tag == "Hurt Box (Player)" && gameMode.currentGameMode == GameModeManager.GameMode.Arcade && player.tag == "Enemy"){
            return true;
        }
        return false;
    }

}
