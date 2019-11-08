using System.Collections;
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
        if(col.gameObject.tag == "Hurt Box" && gameObject.tag != "Hit Box (Enemy)"){

            AttackSideOrigin(Mathf.Sign(player.transform.localScale.x));
//            Debug.Log(gameObject.name + "Did " + attack.attackInfo.damage + " damage and " + attack.attackInfo.hitstun + " hitstun");
            //col.gameObject.GetComponent<DamageDetection>().TakeDamage(attackClass.attackInfo);
            col.gameObject.GetComponent<DamageDetection>().TakeDamage(attackInfo);
            StartCoroutine(status.FreezeCharacter(attackInfo.hitlag));
        }
        if(col.gameObject.tag == "Hurt Box (Player)" && gameMode.currentGameMode == GameModeManager.GameMode.PVP){
            AttackSideOrigin(Mathf.Sign(player.transform.localScale.x));
            col.gameObject.GetComponent<DamageDetection>().TakeDamage(attackInfo);
            StartCoroutine(status.FreezeCharacter(attackInfo.hitlag));
        }
        if(col.gameObject.tag == "Hurt Box (Player)" && gameMode.currentGameMode == GameModeManager.GameMode.Arcade && player.tag == "Enemy"){
            AttackSideOrigin(Mathf.Sign(player.transform.localScale.x));
            col.gameObject.GetComponent<DamageDetection>().TakeDamage(attackInfo);
            StartCoroutine(status.FreezeCharacter(attackInfo.hitlag));
        }
    }


}
