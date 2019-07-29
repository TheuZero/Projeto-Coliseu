using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    Attack attack;
    void Start(){
        attack = transform.parent.gameObject.transform.parent.gameObject.GetComponent<Attack>();
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col == null){
            Debug.Log("wtf");
        }
        if(col.gameObject.tag == "Hurt Box"){
            col.gameObject.GetComponent<DamageDetection>().TakeDamage(attack.DamageCalc(), attack.GetHitstun());
            
        }
    }
}
