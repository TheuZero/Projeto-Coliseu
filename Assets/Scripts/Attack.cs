using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attack = 1f;
    public float hitstun = 0.1f;
    float hitlag = 0.1f;
    float knockback = 0.2f;
    float knockup;
    float attackModifier;
    
    public float DamageCalc(){
        return attack * attackModifier;
    }

    public float GetHitstun(){
        return hitstun;
    }
    public void Combo1(){
        attackModifier = 1;
        hitstun = 0.2f;
    }

    public void Combo2(){
        attackModifier = 1.2f;
        hitstun = 0.3f;
    }

    public void Combo3(){
        attackModifier = 2;
        hitstun = 0.7f;
    }
    public void Combo4(){
        attackModifier = 3;
        hitstun = 1.5f;
    }
}
