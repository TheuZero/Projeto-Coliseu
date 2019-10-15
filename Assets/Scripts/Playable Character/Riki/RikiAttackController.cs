using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RikiAttackController : MonoBehaviour
{
    Animator anim;
    Status status;
    InputOrganizer input;
    GroundDetection gd;
    bool verification;

    void Start()
    {
        anim = GetComponent<Animator>();
        status = GetComponent<Status>();
        input = GetComponent<InputOrganizer>();
        gd = GetComponent<GroundDetection>();
    }

    public bool ComboVerify(){
        verification = false;
        if(status.canAttack && gd.isGrounded){ 
            status.canMove = false;
            anim.SetTrigger("isAttacking");
            verification = true;
        }
        return verification;
    }

    public bool SuperBeatVerify(){
        verification = false;
        if(status.canSpecial && gd.isGrounded){ 
            status.DisableActions();
            anim.SetTrigger("superBeat");
            verification = true;
        }
        return verification;
    }
}
