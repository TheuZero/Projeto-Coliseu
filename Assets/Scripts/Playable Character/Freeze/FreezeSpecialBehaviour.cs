using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeSpecialBehaviour : MonoBehaviour
{
    Status status;

    float timer;
    float movementSpeed = 7f;
    float direction;
    float xSpeed;
    float ySpeed;
    AttackDetection attackDetection;
    
    //scriptable objects
    public AttackData[] attackList = new AttackData[0];
    AttackData attackData;
    MovementationData movementationData;
    Vector2 orientation;

    Movement movement;    
    //temporary
    Animator anim;
    void Start()
    {
        status = GetComponent<Status>();
        attackDetection = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<AttackDetection>();
        movement = GetComponent<Movement>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        if(Input.GetKeyDown("q")){
            anim.SetTrigger("SpecialDash");
        }
    }
    public IEnumerator DashSpecialAttack(int index){
        AssignMovement(index);
        timer = 0.3f;
        while(timer > 0){
            timer -= Time.deltaTime * status.timeFactor;
            movement.MoveCharacter(movementationData);
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }
    void AssignMovement(int index){
        movementationData = attackData.movementData.moveData[index];
    }

    //invocado na animação, já que é impossivel invocar métodos de scripts de outros objetos.
    void SetAttack(int index){
        attackDetection.AttackSideOrigin(transform.localScale.x);
        attackData = attackList[0];
        attackDetection.DamageInsert(attackData);
        attackDetection.SetAttack(index);
    }
}

public class MoveData{

}

