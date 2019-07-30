using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack")){
			anim.SetTrigger("isAttacking");
		}

        if(Input.GetButtonDown("Special")){
            anim.SetBool("icePillar", true);
        }else{
            anim.SetBool("icePillar", false);
        }
    }
}
