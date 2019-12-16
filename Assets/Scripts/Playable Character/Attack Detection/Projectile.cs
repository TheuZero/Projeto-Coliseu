using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    public GameModeManager gameMode;
    public ParticleSystem particle;
    public float speed = 6;
    public float duration = 6f;
    public float timeScale = 1f;
    public float side;
    public int maxHit;
    int hitCounter;
    public float startScale = 1;

    AttackInfo attackInfo;
    public GameObject player;
    
    void Awake(){
        attackInfo = new AttackInfo();
        player = transform.parent.transform.parent.transform.GetChild(0).gameObject;
        particle = GetComponent<ParticleSystem>();
        try{
            gameMode = GameObject.Find("Game Mode Manager").GetComponent<GameModeManager>();
        }catch(Exception e){
            Debug.Log("Gamemode não encontrado, debug");
        }
    }
    void OnEnable(){
        StartCoroutine(Duration(duration));
        SpawnReference();
        attackInfo.side = player.transform.localScale.x;
        side = player.transform.localScale.x;
        hitCounter = maxHit;
    }

    void FixedUpdate(){
        transform.Translate(Vector2.right * (speed * side) * Time.deltaTime * timeScale);
    }

    void SpawnReference(){

        Vector2 projectileSize = transform.localScale;
        side = player.transform.localScale.x * (Mathf.Abs(projectileSize.x));
        particle.startRotation = Mathf.Sign(player.transform.localScale.x) * 1.5708f;
        gameObject.transform.position = new Vector2(player.transform.position.x + side * 0.4f, player.transform.position.y + 0.2f);
        gameObject.transform.localScale = new Vector2(side * startScale, gameObject.transform.localScale.y);
    }

/*  void SetAttack(){
        attackInfo.hitstun = 1;
        attackInfo.damage = 5;
        attackInfo.knockback = 8;
        attackInfo.knockbackDuration = 0.2f;
        attackInfo.knockup = 4.4f;
        attackInfo.knockupDuration = 0.10f;
    }*/

    IEnumerator Duration(float duration){
        while(duration > 0){
            duration -= Time.deltaTime * timeScale;
            yield return new WaitForFixedUpdate();
        }
        gameObject.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if(CanHit(col)){
            hitCounter -= 1;
            if(hitCounter <= 0){
                gameObject.SetActive(false);
            }
        }
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
}
