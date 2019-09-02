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
	
	int isGrounded;
	int isWalking;
	int isDashing;
	int isJumping;
	int isRunning;
	int baseTag;
	InputOrganizer input;
	int jumpInput = InputValues.jump;
	Status status;
	

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
		

		if(Input.GetButtonDown("Horizontal")){
			DashCheck();
		}
		if(Input.GetAxisRaw("Horizontal") == 0){
			movement.isRunning = false;
		}
		//pulo
		if(Input.GetButtonDown("Jump")){
			input.InputCommand(jumpInput);
		}
		if(Input.GetButtonUp("Jump")){
			movement.JumpTimerLimit();
		}
	}
	public bool JumpCheck(){
		bool executed = false;
		if(groundDetection.isGrounded && status.canMove){
				status.canAttack = false;			
				movement.ActivateJump();
				executed = true;
			}
		return executed;
	}

	void FixedUpdate(){
		if(Input.GetAxisRaw("Horizontal") != 0 ){
			movement.Running(Input.GetAxisRaw("Horizontal"));
			if(status.canMove){
				movement.GroundMovement(Input.GetAxisRaw("Horizontal"));
				anim.SetBool(isWalking, true);
			}
		}else{
			anim.SetBool(isWalking, false);
		}

		if(Input.GetButton("Jump")){
			movement.Jump(rb);
		}
		if(groundDetection.isGrounded){
			movement.JumpResetTimer();
		}
		StateUpdate();
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

	void DashCheck(){
		if(lastKeyPressed == Input.GetAxisRaw("Horizontal") && Time.time - lastPressed < doubleTapDashTimer ){
			if(stateInfo.IsTag("Base")){
				movement.ActivateDash(Input.GetAxisRaw("Horizontal"));
			}
			//anim.SetTrigger(isDashing);
			lastKeyPressed = 0;
		}else{
			lastPressed = Time.time;
			if(Input.GetAxisRaw("Horizontal") != 0){
				lastKeyPressed = Input.GetAxisRaw("Horizontal");
			}
		}		
	}
}
