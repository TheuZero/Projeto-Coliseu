﻿using System.Collections;
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
	float lastDirectionPressed;
	public bool canDoubleJump;

	//hashes
	int isGrounded;
	int isWalking;
	int isDashing;
	int isJumping;
	int isRunning;
	int baseTag;
	InputOrganizer input;
	Status status;

	
	bool confirm;

	void Start () {
		groundDetection = GetComponent<GroundDetection>();
		movement = GetComponent<Movement>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		input = GetComponent<InputOrganizer>();
		status = GetComponent<Status>();
		//hashes
		isGrounded = Animator.StringToHash("isGrounded");
		isWalking = Animator.StringToHash("isWalking");
		isDashing = Animator.StringToHash("isDashing");
		isJumping = Animator.StringToHash("isJumping");
		isRunning = Animator.StringToHash("isRunning");
		baseTag = Animator.StringToHash("Base");
	}
	
	// Update is called once per frame
	void Update () {
		stateInfo = anim.GetCurrentAnimatorStateInfo(0);

		if(Input.GetAxisRaw("Horizontal") == 0){
			movement.isRunning = false;
		}
		//pulo

	}
	public bool JumpVerify(){
		bool executed = false;
		if(groundDetection.isGrounded && status.canMove){
			status.canAttack = false;			
			//movement.ActivateJump();
			movement.JumpStart();
			executed = true;
		}else if(!groundDetection.isGrounded && status.canMove && canDoubleJump){
			movement.DoubleJumpStart();
			canDoubleJump = false;
			executed = true;
		}
		return executed;
	}
	public bool ContinuousJump(){
		if(status.canMove){
			movement.Jump(rb);
		}
		return true;
	}


	void FixedUpdate(){
		if(Input.GetAxisRaw("Horizontal") != 0 ){
			//movement.Running(Input.GetAxisRaw("Horizontal"));
		}
			/*if(status.canMove){
				movement.GroundMovement(Input.GetAxisRaw("Horizontal"));
				anim.SetBool(isWalking, true);
			}
		}else{
			anim.SetBool(isWalking, false);
		}*/
		if(groundDetection.isGrounded){
			canDoubleJump = true;
		}

		if(Input.GetButton("Jump")){

		}
		if(groundDetection.isGrounded){
			movement.JumpResetTimer();
		}
		StateUpdate();
	}
	public bool TapRight(){
		DashCheck(1);
		return true;
	}
	public bool TapLeft(){
		DashCheck(-1);
		return true;
	}

	public bool WalkRight(){
		confirm = false;
		lastDirectionPressed = 1;
		if(status.canMove){
			movement.GroundMovement(1);
			anim.SetBool(isWalking, true);
			confirm = true;
			movement.Running(1);
		}else{
			anim.SetBool(isWalking,false);
		}
		return confirm;
	}
	public bool WalkLeft(){
		confirm = false;
		lastDirectionPressed = -1;
		if(status.canMove){
			movement.GroundMovement(-1);
			movement.Running(-1);
			anim.SetBool(isWalking, true);
			confirm = true;
		}else{
			//anim.SetBool(isWalking,false);
		}
		return confirm;
	}
	public void ContinuousWalk(){
		if(anim.GetBool(isWalking)){
			movement.GroundMovement(lastDirectionPressed);
		}
	}
	public bool CancelWalk(){
		confirm = false;
		anim.SetBool(isWalking, false);
		confirm = true;
		movement.CancelRun();
		return confirm;
	}

	void StateUpdate(){
		anim.SetBool(isGrounded, groundDetection.isGrounded);
		anim.SetBool(isJumping, movement.isJumping);
		anim.SetBool(isRunning, movement.isRunning);
		anim.SetBool(isDashing, movement.isDashing);
		if(groundDetection.isGrounded){
			//anim.SetBool("isJumping", false);
		}
	}

	void DashCheck(float lastKeyDir){
		if(lastKeyPressed == lastKeyDir && Time.time - lastPressed < doubleTapDashTimer ){
			if(stateInfo.IsTag("Base")){
				movement.ActivateDash(lastKeyDir);
			}
			//anim.SetTrigger(isDashing);
			lastKeyPressed = 0;
		}else{
			lastPressed = Time.time;
			lastKeyPressed = lastKeyDir;
		}		
	}

	public bool JumpEnd(){
		movement.JumpTimerLimit();
		//anim.SetBool("isJumping", false);
		return true;
	}
}
