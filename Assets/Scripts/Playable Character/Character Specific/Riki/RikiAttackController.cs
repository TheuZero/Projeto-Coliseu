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

    public bool isGrabbing = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        status = GetComponent<Status>();
        input = GetComponent<InputOrganizer>();
        gd = GetComponent<GroundDetection>();
    }

    public bool ComboVerify(){
        verification = false;
        if(status.canAttack && gd.isGrounded || isGrabbing){ 
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
    /* 
    public bool GrabThrow(){
        verification = false;
        if(isGrabbing && gd.isGrounded){
            verification = true;
            anim.SetTrigger("grab");
            anim.SetBool("isGrabbing", false);
            
        }
        return verification;
    }*/

    public bool TechVerify(){
        verification = false;
        if(status.canSpecial && gd.isGrounded || isGrabbing && gd.isGrounded){ 
            status.DisableActions();
            anim.SetTrigger("grab");
            anim.SetBool("isGrabbing", false);
            isGrabbing = false;
            verification = true;
        }
        return verification;
    }

    void StateUpdate(){
        anim.SetBool("isGrabbing", isGrabbing);
    }

    void FixedUpdate(){
        StateUpdate();
    }
}
