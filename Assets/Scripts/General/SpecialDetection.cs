using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDetection : MonoBehaviour
{
    SpecialDamage attack;
    void Start(){
        attack = transform.parent.gameObject.GetComponent<SpecialDamage>();
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col == null){
            Debug.Log("wtf");
        }
        if(col.gameObject.tag == "Hurt Box"){
//            Debug.Log(gameObject.name + "Did " + attack.attackInfo.damage + " damage and " + attack.attackInfo.hitstun + " hitstun");
            col.gameObject.GetComponent<DamageDetection>().TakeDamage(attack.attackInfo);
            
        }
    }
}
