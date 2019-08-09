using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDamage : MonoBehaviour
{
    public AttackInfo attackInfo;
    public AttackData attackData;
    
    GameObject player;
    float side;

    /* 
    public float hitstun = 2;
    public float damage = 5;
    public float knockback = 8;
    public float knockbackDuration = 0.5f;
    public float knockup = 4.4f;
    public float knockupDuration = 0.25f;
    */

    void Awake(){
        attackInfo = new AttackInfo();
        player = transform.parent.transform.parent.transform.GetChild(0).gameObject;
        
    }

    void OnEnable(){
        attackInfo.side = player.transform.localScale.x;
        SetAttack();
    }
    void OnDisable(){

    }

    void SetAttack(){
        attackInfo.hitstun = attackData.Hitstun;
        attackInfo.damage = attackData.DmgMultiplier;
        attackInfo.knockback = attackData.Knockback;
        attackInfo.knockup = attackData.Knockup;
    }
}
