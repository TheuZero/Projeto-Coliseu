﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    public Status status;
    GameObject parent;
    Defense defense;
    Animator anim;
    void Start()
    {
        parent = transform.parent.transform.parent.transform.parent.gameObject;
        defense = parent.GetComponent<Defense>();
        anim = parent.GetComponent<Animator>();
        status = parent.GetComponent<Status>();
    }
    public void TakeDamage(AttackInfo attackInfo){
        
        defense.GrabCancel();
        
        Debug.Log(parent.name + "Has taken " + attackInfo.damage + " damage, " + attackInfo.hitstun + " hitstun, " + attackInfo.hitlag + " hitlag");
        Debug.Log("and" + attackInfo.knockback + "knock back and " + attackInfo.knockup);
        defense.Damaged(attackInfo);
    }
    public void Grabbed(Vector3 position, bool grabbed, float side){
        defense.Grabbed(position, grabbed, side);
        defense.anim.SetTrigger("Hitstunned");
    }
    public void GrabCancel(){
        defense.GrabCancel();
    }
}
