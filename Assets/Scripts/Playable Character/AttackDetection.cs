using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetection : MonoBehaviour
{
    GameObject player;
    Attack attackClass;
    Animator anim;
    public AttackInfo attackInfo;
    Status status;
    AttackData attackData;
    HitData[] hitData;
    public float attackModifier;
    public float attack;
    List<MonoBehaviour> subjects = new List<MonoBehaviour>();

    void Start(){
        player = transform.parent.transform.parent.gameObject.transform.parent.gameObject;
        attackClass = player.GetComponent<Attack>();
        anim = player.GetComponent<Animator>();
        status = player.GetComponent<Status>();
        attackInfo = new AttackInfo();

        SubscribeOnHit();
    }

    void SubscribeOnHit(){
        subjects.Add(player.GetComponent<FreezeSpecialBehaviour>());
    }
    void OnHitNotify(){
        foreach(MonoBehaviour m in subjects){
           // m.OnHit();
        }
    }

    void DamageCalc(){
       attackInfo.damage = attack * attackModifier;
       attackInfo.side = Mathf.Sign(transform.localScale.x);
    }
    public void DamageInsert(AttackData attackData){
        this.attackData = attackData;
    }
    public void AttackSideOrigin(float side){
        attackInfo.side = Mathf.Sign(side);
    }
    //invocado pela animação
    public void SetAttack(int hitData){
        attackInfo.damage = attackData.hitData[hitData].DmgMultiplier;
        attackInfo.knockback = attackData.hitData[hitData].Knockback;
        attackInfo.knockup = attackData.hitData[hitData].Knockup;
        attackInfo.hitstun = attackData.hitData[hitData].Hitstun;
        attackInfo.hitlag = attackData.hitData[hitData].Hitlag;
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col == null){
            Debug.Log("wtf");
        }
        if(col.gameObject.tag == "Hurt Box"){
            attackClass.DamageCalc();
//            Debug.Log(gameObject.name + "Did " + attack.attackInfo.damage + " damage and " + attack.attackInfo.hitstun + " hitstun");
            //col.gameObject.GetComponent<DamageDetection>().TakeDamage(attackClass.attackInfo);
            col.gameObject.GetComponent<DamageDetection>().TakeDamage(attackInfo);
            StartCoroutine(status.FreezeCharacter(attackInfo.hitlag));
        }
    }


}
