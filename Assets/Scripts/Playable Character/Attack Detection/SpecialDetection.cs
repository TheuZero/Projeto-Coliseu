using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDetection : MonoBehaviour
{
    GameObject special;
    SpecialDamage attack;
    Animator anim;
    void Start(){
        special = transform.parent.gameObject;
        anim = special.GetComponent<Animator>();
        attack = special.GetComponent<SpecialDamage>();
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col == null){
            Debug.Log("wtf");
        }
        if(col.gameObject.tag == "Hurt Box"){
//            Debug.Log(gameObject.name + "Did " + attack.attackInfo.damage + " damage and " + attack.attackInfo.hitstun + " hitstun");
            col.gameObject.GetComponent<DamageDetection>().TakeDamage(attack.attackInfo);
            StartCoroutine(Hitfreeze(attack.attackInfo.hitlag));
        }
    }

    IEnumerator Hitfreeze(float timer){
        anim.speed = 0;
        yield return new WaitForSeconds(timer);
        anim.speed = 1;
    }
}
