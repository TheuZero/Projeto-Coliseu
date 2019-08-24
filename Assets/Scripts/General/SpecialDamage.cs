using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDamage : MonoBehaviour
{
    public AttackInfo attackInfo;
    public AttackData attackData;
    int hitData = 0;
    GameObject player;
    float side;


    void Awake(){
        attackInfo = new AttackInfo();
        player = transform.parent.transform.parent.transform.GetChild(0).gameObject;
        
    }

    void OnEnable(){
        attackInfo.side = player.transform.localScale.x;
        SetAttack(hitData);
    }
    void OnDisable(){

    }

    void SetAttack(int hitData){
        attackInfo.damage = attackData.hitData[hitData].DmgMultiplier;
        attackInfo.knockback = attackData.hitData[hitData].Knockback;
        attackInfo.knockup = attackData.hitData[hitData].Knockup;
        attackInfo.hitstun = attackData.hitData[hitData].Hitstun;
        attackInfo.hitlag = attackData.hitData[hitData].Hitlag;
    }
}
