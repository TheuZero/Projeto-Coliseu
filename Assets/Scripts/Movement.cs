using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	//este é unm model, onde fica a lógica do jogo. Ele não tem contato algum com o view.

	public float movementSpeed = 4;
	public float jumpSpeed = 4;
	public float timer = 0f;
	public float maxTimer = 0.5f;


	public void GroundMovement(float direction){
		transform.Translate(Vector2.right * movementSpeed * Time.deltaTime * direction);
		Flip(direction);
	}

	public void Flip(float direction){
		if(transform.localScale.x > 0 && direction < 0 || transform.localScale.x < 0 && direction > 0){
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}

	public void Jump(Rigidbody2D rb){
		if(timer < maxTimer){
			timer += Time.deltaTime;
			transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
			rb.velocity = new Vector2(rb.velocity.x, 0);
		}
	}

	public void ResetTimer(float timer){
		this.timer = timer;
	}

	public void TimerLimit(){
		timer = maxTimer;
	}
}
