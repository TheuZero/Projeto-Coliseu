using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RikiSpecialBehaviour : MonoBehaviour
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
    AttackData actualAttackData;
    MovementationData movementationData;
    Vector2 orientation;

    Movement movement;    
    //temporary
    Animator anim;
    Rigidbody2D rb;
    GroundDetection gd;
    void Start()
    {
        status = GetComponent<Status>();
        attackDetection = transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<AttackDetection>();
        movement = GetComponent<Movement>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponent<GroundDetection>();
    }

    void AssignMovement(int index){
        movementationData = actualAttackData.movementData.moveData[index];
    }

    //invocado na animação, já que é impossivel invocar métodos de scripts de outros objetos.
    // montar um dicionario de dados para a lista em vez de array e fazer lookups por ID

    //por enquanto esse metodo vai ser invocado pelos outros no codigo que irão ser invocado pelo animator
    void SetAttack(int index){
        attackDetection.AttackSideOrigin(transform.localScale.x);
        //attackData = attackList[0];
        attackDetection.SetAttack(actualAttackData, index);
    }

    public void SetComboAttackData(int index){
        actualAttackData = attackList[0];
        SetAttack(index);
    }
    public void ComboMove(int index){
        AssignMovement(index);
        movement.MoveCharacter(movementationData);
    }
    
    public void SetSuperBeatAttack(int index){
        actualAttackData = attackList[1];
        SetAttack(index);
    }

    public void SetGrab(int index){
        actualAttackData = attackList[2];
        SetAttack(index);
    }
    public void SetThrowData(int index){
        actualAttackData = attackList[3];
        SetAttack(index);
    }

    public void SetDiveKickData(int index){
        actualAttackData = attackList[4];
        SetAttack(index);
    }
    public IEnumerator GrabMove(int index){
        AssignMovement(index);
        timer = 0.2f;
        while(timer > 0){
            timer -= Time.deltaTime * status.timeFactor;
            movement.MoveCharacter(movementationData);
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }
    public IEnumerator SuperBeatMove(int index){
        AssignMovement(index);
        timer = 0.4f;
        while(timer > 0){
            timer -= Time.deltaTime * status.timeFactor;
            movement.MoveCharacter(movementationData);
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }

    public IEnumerator DiveKickMove(int index){
        AssignMovement(index);
        while(!gd.isGrounded){
            rb.velocity = new Vector2(0,0);
            movement.MoveCharacter(movementationData);
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }
}

