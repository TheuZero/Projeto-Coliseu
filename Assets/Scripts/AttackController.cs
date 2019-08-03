using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    Animator anim;
    GameObject icePillar;
    GameObject iceBall;
    float side;
    void Start()
    {
        anim = GetComponent<Animator>();
        icePillar = transform.parent.transform.GetChild(1).GetChild(0).gameObject;
        iceBall = transform.parent.transform.GetChild(1).GetChild(1).gameObject;
    }

    void Update()
    {
        if(Input.GetButtonDown("Attack")){
			anim.SetTrigger("isAttacking");
		}

        if(!icePillar.activeSelf){
            if(Input.GetButtonDown("Special")){
                anim.SetBool("icePillar", true);
            }else{
                anim.SetBool("icePillar", false);
            }
        }

        if(!iceBall.activeSelf){
            if(Input.GetButtonDown("Tech")){
                anim.SetBool("iceBall", true);
            }else{
                anim.SetBool("iceBall", false);
            }
        }

    }

    public void ActivateIcePillar(){
        side = transform.localScale.x;
        icePillar.SetActive(true);
        icePillar.transform.position = new Vector2(transform.position.x + side * 0.8f, transform.position.y + 0.12f);
        icePillar.transform.localScale = new Vector2(side, icePillar.transform.localScale.y);
    }

    public void ActivateIceBall(){
        side = transform.localScale.x;
        iceBall.SetActive(true);
        iceBall.transform.position = new Vector2(transform.position.x + side * 0.4f, transform.position.y);
        iceBall.transform.localScale = new Vector2(side, iceBall.transform.localScale.y);
    }
}
