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
        if(status.canAttack && gd.isGrounded){ 
            status.canMove = false;
            anim.SetTrigger("isAttacking");
            verification = true;
        }else if(isGrabbing){
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
    public bool GrabThrow(){
        verification = false;
        if(isGrabbing && gd.isGrounded){
            verification = true;
            anim.SetBool("isGrabbing", false);
            anim.SetTrigger("grab");
            isGrabbing = false;
        }
        return verification;
    }

    public bool GrabVerify(){
        verification = false;
        if(status.canSpecial && gd.isGrounded){ 
            status.DisableActions();
            anim.SetTrigger("grab");
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
