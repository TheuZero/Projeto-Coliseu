using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attack = 1f;

    float attackModifier;
    
    Animator anim;
    public AttackData attackData;
    public AttackInfo attackInfo;

    void Start(){
        attackInfo = new AttackInfo();
        anim = GetComponent<Animator>();
 
    }

    public void DamageCalc(){
       attackInfo.damage = attack * attackModifier;
       attackInfo.side = Mathf.Sign(transform.localScale.x);
    }

    public void Combo1(){
        attackModifier = 1;
        attackInfo.hitstun = 0.2f;
        attackInfo.knockback = 0.2f;
        attackInfo.knockup = 0;
        attackInfo.hitlag = 0.1f;
    }

    public void Combo2(){
        attackModifier = 1.2f;
        attackInfo.hitstun = 0.3f;
        attackInfo.knockback = 0.2f;
        attackInfo.knockup = 0;
        attackInfo.hitlag = 0.1f;
    }

    public void Combo3(){
        attackModifier = 2;
        attackInfo.hitstun = 0.7f;
        attackInfo.knockback = 0.2f;
        attackInfo.knockup = 0;
        attackInfo.hitlag = 0.15f;
    }
    public void Combo4(){
        attackModifier = 3;
        attackInfo.hitstun = 1.5f;
        attackInfo.knockback = 4.2f;
        attackInfo.knockup = 3;
        attackInfo.hitlag = 0.2f;
    }

    public IEnumerator Hitfreeze(float timer){
        anim.speed = 0;
        yield return new WaitForSeconds(timer);
        anim.speed = 1;
    }

    public void ActivateHitfreeze(){
        StartCoroutine(Hitfreeze(attackInfo.hitlag));
    }
}
public class AttackInfo{
    public float hitstun;
    public float hitlag;
    public float knockback;
    public float knockup;
    public float damage;
    public float side;

    public void SetAttributes(){

    }
}
