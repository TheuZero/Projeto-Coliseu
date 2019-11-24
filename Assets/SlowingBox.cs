using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlowingBox : MonoBehaviour
{
    public GameObject player;
    GameModeManager gameMode;
    public List<GameObject> hitted = new List<GameObject>();
    public float secondsSlowed = 4f;
    public float slowEffect = 0.15f;
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
    }
    void OnEnable(){
        hitted.Clear();
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject != player && CanHit(col) && !hitted.Contains(col.gameObject)){
            col.gameObject.GetComponent<DamageDetection>().status.ActivateSlow(slowEffect, secondsSlowed);
            Debug.Log("Slowing box");
            hitted.Add(col.gameObject);
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
