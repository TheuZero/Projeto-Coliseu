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

    void Start()
    {
        anim = GetComponent<Animator>();
        status = GetComponent<Status>();
        icePillar = transform.parent.transform.GetChild(1).GetChild(0).gameObject;
        iceBall = transform.parent.transform.GetChild(1).GetChild(1).gameObject;
        specialEffect = transform.GetChild(4).GetComponent<ParticleSystem>();
        specialScreen = transform.GetChild(5).GetComponent<ParticleSystem>();
        input = GetComponent<InputOrganizer>();


        input.nSpecial = IcePillarVerify;
        input.attack = Combo;
    }

    void Update()
    {
        if(!iceBall.activeSelf){
            if(Input.GetButtonDown("Tech")){
                anim.SetBool("iceBall", true);
            }else{
                anim.SetBool("iceBall", false);
            }
        }

    }
    private bool Combo(){
        bool verification = false;
       
        if(status.canAttack){ 
            status.canMove = false;
            anim.SetTrigger("isAttacking");
            verification = true;
            Debug.Log("executado");
        }
        return verification;
    }

    private bool IcePillarVerify(){
        bool verification = false;
        if(!icePillar.activeSelf && status.canSpecial){
            anim.SetTrigger("icePillar");
            specialEffect.Play();
            specialScreen.Play();
            StartCoroutine(SpecialFreeze(1));
            verification = true;
            status.canAttack = false;
            status.canMove = false;
            status.canSpecial = false;  
        }else{
            verification = false;
        }
        return verification;
    }

    private void ActivateIcePillar(){
        Vector2 pillarSize = icePillar.transform.localScale;
        side = transform.localScale.x * (Mathf.Abs(pillarSize.x));
        icePillar.SetActive(true);
        icePillar.transform.position = new Vector2(transform.position.x + side * 0.8f, transform.position.y + (pillarSize.y * 1.24f) * 0.12f);
        icePillar.transform.localScale = new Vector2(side, icePillar.transform.localScale.y);
    }

    private void ActivateIceBall(){
        side = transform.localScale.x;
        iceBall.SetActive(true);
        iceBall.transform.position = new Vector2(transform.position.x + side * 0.4f, transform.position.y);
        iceBall.transform.localScale = new Vector2(side, iceBall.transform.localScale.y);
    }

    IEnumerator SpecialFreeze(float delay){
        anim.speed = 0;
        yield return new WaitForSeconds(delay);
        anim.speed = 1;
    }
}
