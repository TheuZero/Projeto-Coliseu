using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
	//Controller é a ponte entre o model (lógica) e o view (animator e rendering), também registrando inputs.
	
	public Movement movement;
	Animator anim;
	Rigidbody2D rb;
	AnimatorStateInfo stateInfo;
	float lastKeyPressed;
	float doubleTapDashTimer = 0.4f;
	float lastPressed;
	public GroundDetection groundDetection;
	// Use this for initialization

	void Start () {
		groundDetection = GetComponent<GroundDetection>();
		movement = GetComponent<Movement>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		stateInfo = anim.GetCurrentAnimatorStateInfo(0);

		if(Input.GetButtonDown("Horizontal")){
			if(lastKeyPressed == Input.GetAxisRaw("Horizontal")){
				if(Time.time - lastPressed < doubleTapDashTimer){
					movement.ActivateDash(Input.GetAxisRaw("Horizontal"));
					anim.SetTrigger("isDashing");
					lastKeyPressed = 0;
				}
			}
			lastPressed = Time.time;
			lastKeyPressed = Input.GetAxisRaw("Horizontal");
		}
		//pulo

		//------------ataques---------------
		if(Input.GetButtonDown("Fire1")){
			anim.SetBool("isAttacking", true);
		}
	}

	void FixedUpdate(){
		if(Input.GetAxisRaw("Horizontal") != 0 ){
			if(stateInfo.IsTag("Base")){
				movement.GroundMovement(Input.GetAxisRaw("Horizontal"));
				anim.SetBool("isWalking", true);
			}
		}else{
			anim.SetBool("isWalking", false);
		}

		if(Input.GetButton("Jump")){
			movement.Jump(rb);
		}
		if(Input.GetButtonUp("Jump")){
			movement.JumpTimerLimit();
		}

		//rotina de dash, ativado após o activate dash.
		movement.Dash(Mathf.Sign(transform.localScale.x));
	}

	void Walk(){

	}
}
