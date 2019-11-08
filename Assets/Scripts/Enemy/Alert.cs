using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    //cd between action
    float cooldownTimer;
    
    int comboCounter;
    public Status status;
    public RikiAttackController attack;
    public MovementController movement;
    public GameObject player;
//    public List<Vector3> targetPositions;

    public float defaultIdleTimer = 1f;
    float idleTimer;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Follow(Vector2 target){
        cooldownTimer -= Time.deltaTime;
        if(cooldownTimer <= 0){
            if(player.transform.position.x - target.x > 0.4f){
                movement.WalkLeft();
            }else if(player.transform.position.x - target.x < -0.4f){
                movement.WalkRight();
            }else{
                movement.CancelWalk();
                Attack(player.transform.position.x - target.x);
            }
            Debug.Log(player.transform.position.x - target.x );
        }
    }

    public void Attack(float direction){
        attack.SuperBeatVerify();
        cooldownTimer = 2.0f;
    }
}
