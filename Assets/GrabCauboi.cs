using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCauboi : MonoBehaviour
{
    GameModeManager gameMode;
    GameObject player;
    float grabTimer = 0;
    void Start(){
        player = transform.parent.transform.parent.transform.parent.gameObject;
        gameMode = GameObject.Find("Game Mode Manager").GetComponent<GameModeManager>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(CanHit(col)){
            grabTimer = 1f;
            Debug.Log("Agarrou");
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(CanHit(col)){
            col.gameObject.GetComponent<DamageDetection>().Grabbed(transform.position, true, Mathf.Sign(player.transform.localScale.x));
            GrabDuration(col);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(CanHit(col)){
            col.gameObject.GetComponent<DamageDetection>().Grabbed(transform.position, false, Mathf.Sign(player.transform.localScale.x));
            Debug.Log("saiu");
        }
    }

    void GrabDuration(Collider2D col){
        if(grabTimer > 0){
            grabTimer -= Time.deltaTime;
        }else{
            col.gameObject.GetComponent<DamageDetection>().GrabCancel();
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
