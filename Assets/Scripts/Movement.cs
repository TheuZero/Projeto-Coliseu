using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	//este é o model de movimento, onde fica a lógica do jogo. Ele não tem contato algum com o view.

	public float movementSpeed = 4;
	public float dashSpeed = 12;
	public float runSpeed = 10;
	public float jumpSpeed = 4;
	public float jumpTimer = 0f;
	public float jumpMaxTimer = 0.5f;
	public float dashTimer = 1f;
	public float defaultDashTimer = 0.4f;
	public bool isDashing;
	public float lastDirection;
	public GroundDetection groundDetection;

	void Start(){
		groundDetection = GetComponent<GroundDetection>();
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
	public void Jump(Rigidbody2D rb){
		if(jumpTimer < jumpMaxTimer){
			jumpTimer += Time.deltaTime;
			transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
			rb.velocity = new Vector2(rb.velocity.x, 0);
		}
	}
	public void JumpResetTimer(){
		jumpTimer = 0;
	}

	public void JumpTimerLimit(){
		jumpTimer = jumpMaxTimer;
	}

	public void ActivateDash(float direction){
		//if(groundDetection.isGrounded){
			isDashing = true;
			dashTimer = defaultDashTimer;
			lastDirection = direction;
			Flip(direction);
		//}

	}
	public void Dash(float direction){
		if(isDashing){
			dashTimer -= Time.deltaTime;
			if (dashTimer > 0){
				transform.Translate(Vector2.right * dashSpeed * Time.deltaTime * lastDirection);
			}else{
				isDashing = false;
			}
		}
	}

	public void Running(float direction){
			transform.Translate(Vector2.right * runSpeed * Time.deltaTime * direction);
			Flip(direction);
	}
}
