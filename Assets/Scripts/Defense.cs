using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public float HP = 20;
    float defense;

    bool isHitstunned;
    float hitstunTimer;
    Animator anim;
    int hitstun;
    void Start(){
        anim = GetComponent<Animator>();
        hitstun = Animator.StringToHash("Hitstun");
    }

    void FixedUpdate(){
        Hitstunned();
        StateUpdate();
    }
    
    public void Damaged(AttackInfo attackInfo){
        HP -= attackInfo.damage;
        if(hitstun > 0){
            isHitstunned = true;
            hitstunTimer = attackInfo.hitstun;
        }
    }

    public void Hitstunned(){
        if(isHitstunned){
            hitstunTimer -= Time.deltaTime;
            if(hitstunTimer <= 0){
                isHitstunned = false;
            }
        }
    }

    public void StateUpdate(){
        anim.SetBool(hitstun, isHitstunned);
    }
}
