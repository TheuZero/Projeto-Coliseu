using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attack = 1f;

    float attackModifier;
    
    Animator anim;
    public AttackInfo attackInfo;
    AttackDetection attackDetection;

    void Start(){
        attackInfo = new AttackInfo();
        anim = GetComponent<Animator>();
        attackDetection = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<AttackDetection>();
    }

    public void DamageCalc(){
       attackInfo.damage = attack * attackModifier;
       attackInfo.side = Mathf.Sign(transform.localScale.x);
    }

    public void Combo1(){
        attackDetection.attackInfo.damage = 1;
        attackDetection.attackInfo.hitstun = 0.2f;
        attackDetection.attackInfo.knockback = 0.2f;
        attackDetection.attackInfo.knockup = 0;
        attackDetection.attackInfo.hitlag = 0.1f;
        attackDetection.AttackSideOrigin(transform.localScale.x);
    }

    public void Combo2(){
        attackDetection.attackInfo.damage = 1.2f;
        attackDetection.attackInfo.hitstun = 0.3f;
        attackDetection.attackInfo.knockback = 0.2f;
        attackDetection.attackInfo.knockup = 0;
        attackDetection.attackInfo.hitlag = 0.1f;
        attackDetection.AttackSideOrigin(transform.localScale.x);
    }

    public void Combo3(){
        attackDetection.attackInfo.damage = 2;
        attackDetection.attackInfo.hitstun = 0.7f;
        attackDetection.attackInfo.knockback = 0.2f;
        attackDetection.attackInfo.knockup = 0;
        attackDetection.attackInfo.hitlag = 0.15f;
        attackDetection.AttackSideOrigin(transform.localScale.x);
    }
    public void Combo4(){
        attackDetection.attackInfo.damage = 3;
        attackDetection.attackInfo.hitstun = 1.5f;
        attackDetection.attackInfo.knockback = 4.2f;
        attackDetection.attackInfo.knockup = 3;
        attackDetection.attackInfo.hitlag = 0.2f;
        attackDetection.AttackSideOrigin(transform.localScale.x);
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
