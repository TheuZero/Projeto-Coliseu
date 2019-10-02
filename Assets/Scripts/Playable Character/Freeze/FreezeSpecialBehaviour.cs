using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpecialBehaviour : MonoBehaviour
{
    Status status;

    float timer;
    float movementSpeed = 7f;
    float direction;
    AttackDetection attackDetection;    
    //temporary
    Animator anim;
    void Start()
    {
        status = GetComponent<Status>();
        attackDetection = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<AttackDetection>();
        //temp
        anim = GetComponent<Animator>();
    }

    void Update(){
        if(Input.GetKeyDown("q")){
            anim.SetTrigger("SpecialDash");
        }
    }
    public IEnumerator DashSpecialAttack(){
        timer = 0.3f;
        GetDirection();
        while(timer > 0){
            timer -= Time.deltaTime;
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime * direction);
            yield return null;
        }
    }

    void GetDirection(){
        direction = Mathf.Sign(transform.localScale.x);
    }
}

