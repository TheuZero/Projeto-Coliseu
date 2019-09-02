using System.Collections;
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
	public float jumpMaxTimer = 0.5f;
	public float jumpSquat = 0.1f;
	public float maxJumpSquat = 0.1f;
	public float dashTimer = 0f;
	public float defaultDashTimer = 0.4f;
	public float airDashTimer = 0f;
	public float defaultAirDashTimer = 0.4f;
	public float gravityTimer = 0.2f;
	public float defaultGravityTimer = 0.2f;
	//states
	public bool isDashing;
	public bool isAirDashing;
	public bool isJumping;
	public bool isRunning;

	public float lastDirection;
	public GroundDetection groundDetection;

	public Rigidbody2D rb;
	void Start(){
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
			transform.Translate(Vector2.right * movementSpeed * Time.deltaTime * direction);
			Flip(direction);
		}
	}
	public void Flip(float direction){
		if(transform.localScale.x > 0 && direction < 0 || transform.localScale.x < 0 && direction > 0){
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}

	public void ActivateJump(){
		transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
		isJumping = true;
	}

	public void Jump(Rigidbody2D rb){
		if(isJumping){
			if(jumpTimer < jumpMaxTimer){
				jumpTimer += Time.deltaTime;
				transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
				rb.velocity = new Vector2(rb.velocity.x, 0);
			}else{
				isJumping = false;
			}
		}
	}
	public void JumpResetTimer(){
		jumpTimer = 0;
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
		if(isDashing){
			dashTimer -= Time.deltaTime;
			gravityTimer -= Time.deltaTime;
			if (dashTimer > 0){
				transform.Translate((Vector2.right * dashSpeed * Time.deltaTime * direction) * (4 * dashTimer));
			}else if(dashTimer < 0.1){
				isDashing = false;
			}
		}
	}

	public void AirDash(float direction){
		if(isAirDashing){
			airDashTimer -= Time.deltaTime;
			gravityTimer -= Time.deltaTime;
			if (airDashTimer > 0){
				transform.Translate((Vector2.right * dashSpeed * Time.deltaTime * lastDirection) * (4 * airDashTimer));
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
			transform.Translate(Vector2.right * runSpeed * Time.deltaTime * direction);
			Flip(direction);
		}
	}

}
