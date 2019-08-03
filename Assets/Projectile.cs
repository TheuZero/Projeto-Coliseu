using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 6;
    public float duration = 6f;
    public float side;

    AttackInfo attackInfo;
    
    void Start(){
        attackInfo = new AttackInfo();
    }
    void OnEnable(){

        SetAttack();
    }

    void FixedUpdate(){
        transform.Translate(Vector2.right * (speed * side) * Time.deltaTime);
    }

    void SetAttack(){
        attackInfo.hitstun = 1;
        attackInfo.damage = 5;
        attackInfo.knockback = 8;
        attackInfo.knockbackDuration = 0.2f;
        attackInfo.knockup = 4.4f;
        attackInfo.knockupDuration = 0.10f;
    }
}
