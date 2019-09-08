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

    void Start()
    {
        anim = GetComponent<Animator>();
        status = GetComponent<Status>();
        icePillar = transform.parent.transform.GetChild(1).GetChild(0).gameObject;
        iceBall = transform.parent.transform.GetChild(1).GetChild(1).gameObject;
        input = GetComponent<InputOrganizer>();
        input.nSpecial = IcePillarVerify;
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

    private bool IcePillarVerify(){
        bool verification;
        if(!icePillar.activeSelf){
            anim.SetBool("icePillar", true);
            verification = true;
        }else{
            verification = false;
        }
        anim.SetBool("icePillar", false);
        return verification;
    }

    private void ActivateIcePillar(){
        side = transform.localScale.x;
        icePillar.SetActive(true);
        icePillar.transform.position = new Vector2(transform.position.x + side * 0.8f, transform.position.y + 0.12f);
        icePillar.transform.localScale = new Vector2(side, icePillar.transform.localScale.y);
    }

    private void ActivateIceBall(){
        side = transform.localScale.x;
        iceBall.SetActive(true);
        iceBall.transform.position = new Vector2(transform.position.x + side * 0.4f, transform.position.y);
        iceBall.transform.localScale = new Vector2(side, iceBall.transform.localScale.y);
    }
}
