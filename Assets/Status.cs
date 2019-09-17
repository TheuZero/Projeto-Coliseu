using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public float mp;
    public float maxMp;
    float timeFactor;
    public bool canMove;
    public bool canAttack;
    public bool canSpecial;
    Animator anim;
    AnimatorStateInfo stateInfo;
    AnimatorStateInfo previousStateInfo;
    int baseTag;
    void Start()
    {
        anim = GetComponent<Animator>();
        baseTag = Animator.StringToHash("Base");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){
        stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if(stateInfo.fullPathHash != previousStateInfo.fullPathHash){
            if(stateInfo.tagHash == baseTag){
                canMove = true;
                canAttack = true;
                canSpecial = true;
            }
        }
        previousStateInfo = anim.GetCurrentAnimatorStateInfo(0);
    }
}
