using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    Animator anim;
    GameObject icePillar;
    GameObject iceBall;
    float side;
    Status status;
    InputOrganizer input;
    ParticleSystem specialEffect;
    ParticleSystem specialScreen;

    bool verification;

    void Start()
    {
        anim = GetComponent<Animator>();
        status = GetComponent<Status>();
        icePillar = transform.parent.transform.GetChild(1).GetChild(0).gameObject;
        iceBall = transform.parent.transform.GetChild(1).GetChild(1).gameObject;
        specialEffect = transform.GetChild(4).GetComponent<ParticleSystem>();
        specialScreen = transform.GetChild(5).GetComponent<ParticleSystem>();
        input = GetComponent<InputOrganizer>();


        //input.nSpecial = IcePillarVerify;
        //input.attack = Combo;
    }

    void Update()
    {

    }
    public bool ComboVerify(){
        verification = false;
       
        if(status.canAttack){ 
            status.canMove = false;
            anim.SetTrigger("isAttacking");
            verification = true;
            Debug.Log("executado");
        }
        return verification;
    }

    public bool IcePillarVerify(){
        verification = false;
        if(!icePillar.activeSelf && status.canSpecial){
            anim.SetTrigger("icePillar");
            StartCoroutine(SpecialFreeze(1));
            verification = true;
            DisableActions();
        }else{
            verification = false;
        }
        return verification;
    }

    public bool IceBallVerify(){
        verification = false;
        if(!iceBall.activeSelf && status.canSpecial){
            verification = true;
            anim.SetTrigger("iceBall");
            DisableActions();
        }
        return verification;
    }

    private void DisableActions(){
        status.canAttack = false;
        status.canMove = false;
        status.canSpecial = false;  
    }
    private void ActivateIcePillar(){
        icePillar.SetActive(true);
    }

    private void ActivateIceBall(){
        iceBall.SetActive(true);
    }

    IEnumerator SpecialFreeze(float delay){
        specialEffect.Play();
        specialScreen.Play();
        anim.speed = 0;
        yield return new WaitForSeconds(delay);
        anim.speed = 1;
    }
}
