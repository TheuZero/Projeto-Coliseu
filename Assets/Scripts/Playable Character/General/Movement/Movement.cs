﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	//este é o model de movimento, onde fica a lógica do jogo. Ele não tem contato algum com o view.
	public float movementSpeed = 4;
	public float dashSpeed = 12;
	public float runSpeed = 10;

	//timers
	public float jumpSpeed = 4;
	public float jumpTimer = 0f;
	public float jumpMaxTimer = 0.2f;
	public float jumpSquat = 0;
	public float maxJumpSquat = 0.15f;
	public float dashTimer = 0f;
	public float defaultDashTimer = 0.4f;
	public float airDashTimer = 0f;
	public float defaultAirDashTimer = 0.4f;
	public float gravityTimer = 0.2f;
	public float defaultGravityTimer = 0.2f;
	public float doubleJumpTimer = 0.15f;
	public float defaultDoubleJumpTimer = 0.15f;
	//states
	public bool isDashing;
	public bool isAirDashing;
	public bool isJumping;
	public bool isRunning;
	public bool initiateJump;
	public bool doubleJumping;
	public bool doubleJump;

	//S.O
	float direction;
	float xSpeed;
	float ySpeed;
	Vector2 orientation;

	public float lastDirection;
	public GroundDetection groundDetection;

	public Rigidbody2D rb;

	Status status;
	void Start(){
		status = GetComponent<Status>();
		groundDetection = GetComponent<GroundDetection>();
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate(){
		//rotina de dash, ativado após o activate dash.
		Dash(Mathf.Sign(transform.localScale.x));
		AirDash(Mathf.Sign(transform.localScale.x));
	}

	public void GroundMovement(float direction){
		if(!isDashing){
			transform.Translate(Vector2.right * movementSpeed * Time.deltaTime * status.timeFactor * direction);
			Flip(direction);
		}
	}
	public void Flip(float direction){
		if(transform.localScale.x > 0 && direction < 0 || transform.localScale.x < 0 && direction > 0){
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}

	IEnumerator StartJumping(){
		jumpSquat = maxJumpSquat;
		while(jumpSquat > 0){
			initiateJump = true;
			jumpSquat -= Time.deltaTime * status.timeFactor;
			yield return new WaitForFixedUpdate();
		}
		initiateJump = false;
		ActivateJump();
		yield break;
	}
	public void JumpStart(){
		if(!initiateJump)
		StartCoroutine(StartJumping());
	}
	public void DoubleJumpStart(){
		if(!doubleJumping)
		StartCoroutine(DoubleJump());
	} 
	IEnumerator DoubleJump(){
		doubleJumpTimer = defaultDoubleJumpTimer;
		while(doubleJumpTimer > 0 && status.canMove){
			isJumping = true;
			rb.velocity = new Vector2(0,0);
			doubleJumping = true;
			doubleJumpTimer -= Time.deltaTime * status.timeFactor;
			transform.Translate(Vector2.up * Time.deltaTime * status.timeFactor * jumpSpeed);
			yield return new WaitForFixedUpdate();
		}
		isJumping = false;
		doubleJumping = false;
		yield break;
	}
	public void ActivateJump(){
		transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime * status.timeFactor);
		isJumping = true;
	}

	public void Jump(Rigidbody2D rb){
		if(isJumping){
			if(jumpTimer < jumpMaxTimer){
				jumpTimer += Time.deltaTime * status.timeFactor;
				transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime * status.timeFactor);
				rb.velocity = new Vector2(rb.velocity.x, 0);
			}else if(!doubleJumping){
				isJumping = false;
			}
		}
	}
	public void JumpResetTimer(){
		jumpTimer = 0;
		if(initiateJump){
			isJumping = true;
		}else{
			isJumping = false;
		}
	}

	public void JumpTimerLimit(){
		isJumping = false;
		jumpTimer = jumpMaxTimer;
	}

	public void ActivateDash(float direction){
		if(groundDetection.isGrounded){
			isDashing = true;
			airDashTimer = defaultAirDashTimer;
			dashTimer = defaultDashTimer;
			lastDirection = direction;
			Flip(direction);
		}else{
			isAirDashing = true;
			airDashTimer = defaultAirDashTimer;
			dashTimer = defaultDashTimer;
			lastDirection = direction;
			Flip(direction);
		}

	}

	public void Dash(float direction){
		if(status.canMove){
			if(isDashing){
				dashTimer -= Time.deltaTime * status.timeFactor;
				gravityTimer -= Time.deltaTime * status.timeFactor;
				if (dashTimer > 0){
					transform.Translate((Vector2.right * dashSpeed * Time.deltaTime * status.timeFactor * direction) * (4 * dashTimer));
				}else if(dashTimer < 0.1){
					isDashing = false;
				}
			}
		}else{
			isDashing = false;
			dashTimer = 0;
		}
	}

	public void AirDash(float direction){
		if(isAirDashing){
			airDashTimer -= Time.deltaTime * status.timeFactor;
			gravityTimer -= Time.deltaTime * status.timeFactor;
			if (airDashTimer > 0){
				transform.Translate((Vector2.right * dashSpeed * Time.deltaTime * status.timeFactor * lastDirection) * (4 * airDashTimer));
				if(gravityTimer > 0){
					rb.velocity = new Vector3(0,-1,0);
				}
			}else{
				isAirDashing = false;
				gravityTimer = defaultGravityTimer;
			}
		}
	}

	public void ActivateRun(float direction){
		if(isDashing || isAirDashing){
			if(direction == transform.localScale.x){
				if(dashTimer < defaultDashTimer / 3 || airDashTimer < defaultAirDashTimer / 3){
					isDashing = false;
					isRunning = true;					
				}
			}
		}
	}

	public void Running(float direction){
		ActivateRun(direction);
		if(isRunning){
			transform.Translate(Vector2.right * runSpeed * Time.deltaTime * status.timeFactor * direction);
			Flip(direction);
		}
	}

	public void CancelRun(){
		isRunning = false;
	}

	public void MoveCharacter(MovementationData moveData){
		GetDirection();
		xSpeed = moveData.XSpeed;
        ySpeed = moveData.YSpeed;
        orientation = new Vector2(moveData.XOrientation, moveData.YOrientation);

        transform.Translate(Vector2.right * xSpeed * Time.deltaTime * orientation.x * direction * status.timeFactor);
        transform.Translate(Vector2.up * ySpeed * Time.deltaTime * orientation.y * status.timeFactor);
    }

	void GetDirection(){
        direction = Mathf.Sign(transform.localScale.x);
    }


}
