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
	

	void Start () {
		groundDetection = GetComponent<GroundDetection>();
		movement = GetComponent<Movement>();
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();

		//hashes
		isGrounded = Animator.StringToHash("isGrounded");
		isWalking = Animator.StringToHash("isWalking");
		isDashing = Animator.StringToHash("isDashing");
		isJumping = Animator.StringToHash("isJumping");
		isRunning = Animator.StringToHash("isRunning");
	}
	
	// Update is called once per frame
	void Update () {
		stateInfo = anim.GetCurrentAnimatorStateInfo(0);

		if(Input.GetButtonDown("Horizontal")){
			if(lastKeyPressed == Input.GetAxisRaw("Horizontal")){
				if(Time.time - lastPressed < doubleTapDashTimer){
					movement.ActivateDash(Input.GetAxisRaw("Horizontal"));
					anim.SetTrigger(isDashing);
					lastKeyPressed = 0;
				}
			}
			lastPressed = Time.time;
			if(Input.GetAxisRaw("Horizontal") != 0){
				lastKeyPressed = Input.GetAxisRaw("Horizontal");
			}
		}
		if(Input.GetAxisRaw("Horizontal") == 0){
			movement.isRunning = false;
		}
		//pulo
		if(Input.GetButtonDown("Jump")){
			if(groundDetection.isGrounded){
				movement.ActivateJump();
				//anim.SetBool("isJumping", true);
			}
		}
		if(Input.GetButtonUp("Jump")){
			movement.JumpTimerLimit();
		}

		//------------ataques---------------
		if(Input.GetButtonDown("Fire1")){
			anim.SetTrigger("isAttacking");
		}
	}

	void FixedUpdate(){
		if(Input.GetAxisRaw("Horizontal") != 0 ){
			movement.Running(Input.GetAxisRaw("Horizontal"));
			if(stateInfo.IsTag("Base")){
				movement.GroundMovement(Input.GetAxisRaw("Horizontal"));
				anim.SetBool(isWalking, true);
			}
		}else{
			anim.SetBool(isWalking, false);
		}

		if(Input.GetButton("Jump")){
			movement.Jump(rb);
		}

		StateUpdate();
	}

	void StateUpdate(){
		anim.SetBool(isGrounded, groundDetection.isGrounded);
		anim.SetBool(isJumping, movement.isJumping);
		anim.SetBool(isRunning, movement.isRunning);
	}
}
