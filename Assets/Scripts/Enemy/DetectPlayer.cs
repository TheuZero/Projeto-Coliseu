using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public Patrol patrol;
    void OnTriggerEnter2D(Collider2D col){
        
        if(col.gameObject.tag == "Player"){
            patrol.AlertMode();
            Debug.Log(col.gameObject.name);
        }

    }
}
