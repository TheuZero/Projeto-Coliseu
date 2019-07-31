using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attack = 1f;
    float hitstun = 0.1f;
    //float hitlag = 0.1f;
    //float knockback = 0.2f;
    //float knockup;
    float attackModifier;

    public AttackInfo attackInfo;

    void Start(){
        attackInfo = new AttackInfo();
    }

    public void DamageCalc(){
       attackInfo.damage = attack * attackModifier;
    }

    public float GetHitstun(){
        return hitstun;
    }
    public void Combo1(){
        attackModifier = 1;
        attackInfo.hitstun = 0.2f;
    }

    public void Combo2(){
        attackModifier = 1.2f;
        attackInfo.hitstun = 0.3f;
    }

    public void Combo3(){
        attackModifier = 2;
        attackInfo.hitstun = 0.7f;
    }
    public void Combo4(){
        attackModifier = 3;
        attackInfo.hitstun = 1.5f;
    }

    public void IcePillar1(){
        attackModifier = 0;
        attackInfo.hitstun = 1;
    }

    public void IcePillar2(){
        attackModifier = 3;
        attackInfo.hitstun = 3f;
    }
}
public class AttackInfo{
    public float hitstun;
    public float hitlag;
    public float knockback;
    public float knockup;
    public float damage;
}
