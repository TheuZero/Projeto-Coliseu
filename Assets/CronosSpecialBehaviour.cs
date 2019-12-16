using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CronosSpecialBehaviour : MonoBehaviour
{
    Status status;

    float timer;

    AttackDetection attackDetection;
    
    //scriptable objects
    public AttackData[] attackList = new AttackData[0];
    public GameObject[] projectiles = new GameObject[0];
    AttackData actualAttackData;
    MovementationData movementationData;

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
    public void SetSuperBeatData(int index){
        actualAttackData = attackList[1];
        SetAttack(index);
    }
    public void SetGrabKickData(int index){
        actualAttackData = attackList[2];
        SetAttack(index);
    }
    public void ComboMove(int index){
        AssignMovement(index);
        movement.MoveCharacter(movementationData);
    }

    public void EnableProjectile(int index){
        projectiles[index].SetActive(true);
    }
}
