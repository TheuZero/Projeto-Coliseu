using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpecialDamage : MonoBehaviour
{
    public AttackInfo attackInfo;
    public AttackData attackData;
    public GameModeManager gameMode;
    public Projectile projectile;
    int hitData = 0;
    GameObject player;
    float side;


    void Awake(){
        attackInfo = new AttackInfo();
        player = transform.parent.transform.parent.transform.GetChild(0).gameObject;
        projectile = transform.parent.GetComponent<Projectile>();
        try{
            gameMode = GameObject.Find("Game Mode Manager").GetComponent<GameModeManager>();
        }catch(Exception e){
            Debug.Log("Gamemode não encontrado, debug");
        }
    }

    void OnEnable(){
        attackInfo.side = player.transform.localScale.x;
        SetAttack(hitData);
    }
    void OnDisable(){

    }

    void SetAttack(int hitData){
        attackInfo.damage = attackData.hitData[hitData].DmgMultiplier;
        attackInfo.knockback = attackData.hitData[hitData].Knockback;
        attackInfo.knockup = attackData.hitData[hitData].Knockup;
        attackInfo.hitstun = attackData.hitData[hitData].Hitstun;
        attackInfo.hitlag = attackData.hitData[hitData].Hitlag;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(CanHit(col)){
            col.gameObject.GetComponent<DamageDetection>().TakeDamage(attackInfo);
        }
        Debug.Log("colidiu");
    }
    bool CanHit(Collider2D col){
        bool confirm = false;
        if(col.gameObject.tag == "Hurt Box" && gameObject.tag != "Hit Box (Enemy)"){
            confirm = true;
        }
        if(col.gameObject.tag == "Hurt Box (Player)" && gameMode.currentGameMode == GameModeManager.GameMode.PVP){
            confirm = true;
        }
        if(col.gameObject.tag == "Hurt Box (Player)" && gameMode.currentGameMode == GameModeManager.GameMode.Arcade && player.tag == "Enemy"){
            confirm = true;
        }
        return confirm;
    }
    
    IEnumerator HitStop(float hitlag){
        while(hitlag > 0){
            projectile.timeScale = 0;
            hitlag -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        projectile.timeScale = 1f;
    }
}
