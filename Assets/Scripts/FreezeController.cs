using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeController : MonoBehaviour {
	//Controller é a ponte entre o model (lógica) e o view (animator e rendering), também registrando inputs.
	
	public Movement movement;
	Animator anim;
	Rigidbody2D rb;
	AnimatorStateInfo stateInfo;
	// Use this for initialization
	void Start () {
		movement = GetComponent<Movement>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		//movimentação básica
		if(Input.GetAxisRaw("Horizontal") != 0 && stateInfo.IsTag("Base")){
			movement.GroundMovement(Input.GetAxisRaw("Horizontal"));
			anim.SetBool("isWalking", true);
		}else{
			anim.SetBool("isWalking", false);
		}


		//pulo



		//------------ataques---------------
		if(Input.GetButtonDown("Fire1")){
			anim.SetBool("isAttacking", true);
		}
	}

	void FixedUpdate(){
		if(Input.GetButton("Jump")){
			movement.Jump(rb);
		}
		if(Input.GetButtonUp("Jump")){
			movement.TimerLimit();
		}
	}
}
