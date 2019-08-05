using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillar : MonoBehaviour
{   
    GameObject special;
    public AttackInfo attackInfo;

    float hitstun = 2;
    float damage = 5;
    float knockback = 8;
    float knockbackDuration = 0.5f;
    float knockup = 4.4f;
    float knockupDuration = 0.25f;
    
    void Awake(){
        attackInfo = new AttackInfo();
        SetAttack();
    }
    void OnEnable(){
        StartCoroutine("Duration");
        //gameObject.transform.SetParent(special.transform, false);
    }
    void OnDisable(){
        //gameObject.transform.SetParent(special.transform);
    }
    void SetAttack(){
        attackInfo.hitstun = hitstun;
        attackInfo.damage = damage;
        attackInfo.knockback = knockback;
        attackInfo.knockbackDuration = knockbackDuration;
        attackInfo.knockup = knockup;
        attackInfo.knockupDuration = knockupDuration;
    }
    IEnumerator Duration(){
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
