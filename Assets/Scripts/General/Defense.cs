using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    GroundDetection gd;
    
    public float HP = 20;
    public float weight = 10;
    float defense;
    bool isHitstunned;
    float hitstunTimer;
    float knockback;
    float knockbackDuration;
    float knockup;
    float knockupDuration;
    float side;

    int hitstun;
    int launch;
    int fall;

    void Start(){
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponent<GroundDetection>();
        hitstun = Animator.StringToHash("Hitstun");
        launch = Animator.StringToHash("Launch");
        fall = Animator.StringToHash("Fall");
    }

    void FixedUpdate(){
        Hitstunned();
        StateUpdate();
        ApplyKnockback();
        ApplyKnockup();

        if(gd.isGrounded){
            anim.SetBool(launch, false);
        }

        if(Input.GetKey("q")){
            anim.SetBool(fall, false);
        }
    }
    
    public void Damaged(AttackInfo attackInfo){
        HP -= attackInfo.damage;
        if(hitstun > 0){
            isHitstunned = true;
            hitstunTimer = attackInfo.hitstun;
        }

        knockback = attackInfo.knockback;
        knockbackDuration = attackInfo.knockbackDuration;
        side = attackInfo.side;
        knockup = attackInfo.knockup;
        knockupDuration = attackInfo.knockupDuration;
        
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
            knockbackDuration -= Time.deltaTime;
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
            knockupDuration -= Time.deltaTime;
            if(knockup < 0 ){
                knockup = 0;
            }
            transform.Translate(Vector2.up * knockup * Time.deltaTime);
            anim.SetBool(launch, true);
            anim.SetBool(fall, true);
        }
    }

    public void StateUpdate(){
        anim.SetBool(hitstun, isHitstunned);
    }
}
