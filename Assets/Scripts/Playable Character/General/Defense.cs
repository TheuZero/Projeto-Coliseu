using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    GroundDetection gd;
    Status status;
    
    //public float HP = 20;
    public float weight = 10;
    float defense;
    bool isHitstunned;
    float hitstunTimer;
    float knockback;
    float knockup;
    float side;

    float hitlagTimer;
    //animator
    int hitstun;
    int launch;
    int fall;
    GameObject entityCollider;

    void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponent<GroundDetection>();
        status = GetComponent<Status>();
        entityCollider = transform.GetChild(1).GetChild(1).GetChild(2).gameObject;

        hitstun = Animator.StringToHash("Hitstun");
        launch = Animator.StringToHash("Launch");
        fall = Animator.StringToHash("Fall");
    }

    void FixedUpdate(){
        StateUpdate();
        if(hitlagTimer <= 0){
            anim.speed = 1;
            Hitstunned();

            ApplyKnockback();
            ApplyKnockup();

            if(gd.isGrounded && knockup <= 0){
                anim.SetBool(launch, false);
            }

            if(Input.GetKey("q")){
                anim.SetBool(fall, false);
            }
        }else{
            anim.speed = 0;
            hitlagTimer -= Time.deltaTime;
        }
    }
    
    public void Damaged(AttackInfo attackInfo){
        status.ReduceHp(attackInfo.damage);
        if(hitstun > 0){
            isHitstunned = true;
            hitstunTimer = attackInfo.hitstun;
            hitlagTimer = attackInfo.hitlag;
        }

        knockback = attackInfo.knockback;
        side = attackInfo.side;
        knockup = attackInfo.knockup;
        
    }

    public void Hitstunned(){
        if(isHitstunned){
            hitstunTimer -= Time.deltaTime;
            if(hitstunTimer <= 0){
                isHitstunned = false;
            }
        }
    }

    public void ApplyKnockback(){
        if(knockback > 0){
            knockback -= Time.deltaTime * weight;
            if(knockback < 0){
                knockback = 0;
            }
            transform.Translate(Vector2.right * knockback * Time.deltaTime * side);
        }
    }

    public void ApplyKnockup(){
        if(knockup > 0){
            rb.velocity = new Vector2(rb.velocity.x, 0);
            knockup -= Time.deltaTime * weight;
            anim.SetBool(launch, true);
            transform.Translate(Vector2.up * knockup * Time.deltaTime);
            anim.SetBool(fall, true);
        }
        if(knockup <= 0 ){
            knockup = 0;
        }
    }
    public void Grabbed(Vector3 position, bool grabbed, float side){
        if(transform.localScale.x == side){
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }
        Vector3 finalPos = position;
        if(grabbed){
            entityCollider.SetActive(false);
            transform.position = finalPos;
            isHitstunned = true;
            hitstunTimer = 0.4f;
        }else if(!grabbed){
            entityCollider.SetActive(true);
            knockback = 0.3f * weight;
        }
    }
    public void GrabCancel(){
        entityCollider.SetActive(true);
        knockback = 0.3f * weight;
    }
    public void StateUpdate(){
        anim.SetBool(hitstun, isHitstunned);
    }
}
