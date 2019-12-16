using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileDetector : MonoBehaviour
{
    public Transform player;
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            if(col.gameObject.transform.position.x - player.position.x > 0){
                player.localScale = new Vector3(1, player.localScale.y, player.localScale.z);
            }else{
                player.localScale = new Vector3(-1, player.localScale.y, player.localScale.z);
            }
        }
    }
}
