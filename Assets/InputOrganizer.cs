using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOrganizer : MonoBehaviour
{
    [SerializeField]
    public InputBufferItem[] buffer = new InputBufferItem[12];
    public float maxFlushTimer = 2.33f;
    public float flushTimer = 0;

    public bool confirm;

    Animator anim;
    MovementController movement;
    Status status;

    public delegate bool neutralSpecial();
    public neutralSpecial nSpecial;

    void Start()
    {
        for(int i = 0; i < buffer.Length; i++){
            buffer[i] = new InputBufferItem();
        }
        anim = GetComponent<Animator>();
        movement = GetComponent<MovementController>();
        status = GetComponent<Status>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.A)){
            Debug.Log(buffer[0].command);
        }
        CheckCommand();
        FlushBuffer();
    }

    public void InputCommand(int command, int type){
        for (int i = 0; i < buffer.Length - 1; i++){
            buffer[i + 1] = buffer[i];
            buffer[i + 1] = buffer[i];
        }
        buffer[0].command = command;
        buffer[0].used = false;
        flushTimer = 0;
    }

    private void FlushBuffer(){
        flushTimer += Time.deltaTime;
        if(flushTimer > maxFlushTimer){
            for(int i = 0; i < buffer.Length; i++){
                buffer[i].command = 0;
                buffer[i].used = false;
            }
            Debug.Log("Flushed buffer");
            flushTimer = 0;
        }
    }

    private void CheckCommand(){
        for(int i = buffer.Length - 1; i > 0; i--){
            if(!buffer[i].used){
                buffer[i].used = Execute(buffer[i].command, buffer[i].type);
                i = 0;
            }
        }
    }

    private bool Execute(int command, int type){
        confirm = false;
        Debug.Log("Executou o comando");
        if(command == 0){
            confirm = true;
        }
        if(command == InputValues.move){

        }
        if(command == InputValues.jump){
            if(type == InputType.down){
                confirm = movement.JumpCheck();
            }
            if(type == InputType.up){
                confirm = movement.JumpEnd();
            }
        }
        if(command == InputValues.attack){
            if(status.canAttack){
                status.canMove = false;
                anim.SetTrigger("isAttacking");
                
                Debug.Log("Atacou");
                confirm = true;
            }
        }
        if(command == InputValues.nSpecial){
            confirm = nSpecial();
        }
        if(confirm){
            flushTimer = 0;
        }
        return confirm;
    }
}

public class InputBufferItem{
    public InputBufferItem(){
        command = 0;
        used = false;
    }
    public int command = 0;
    public bool used = false;
    public int type;
}
static class InputValues{
    public static int move = 3;
    public static int dash = 1;
    public static int jump = 2;
    public static int attack = 10;
    public static int fAttack = 11;
    public static int dAttack = 12;
    public static int upAttack = 13;
    public static int nSpecial = 20;

    //montar uma lista de valores para cada tipo de ataque, especialmente se eles dependerem de dois botões simultaneamente.
    //montar uma comparação de valores recebidos dos input com os da classe e reagir de acordo no InputOrganizer, assim que for possível completar, tirar da lista,
    //caso contrário, esperar o tempo antes de zerar
    //Talvez manter somente dois elementos, fazer o tempo resetar somente quando o Input for concluído, caso contrário, remover o resto da lista.
}

//colocar o resto dos botões o input buffer, tanto o aperto, segurar e soltar
static class InputType{
    public static int down = 0;
    public static int hold = 1;
    public static int up = 2;
}

//para fazer movimentos que precisam de mais de um botão para sair, seria bom mandar a lista do buffer atual como parametro
//para o comando e ele fazer todas as verificações necessárias antes de escolher a ação para ser executada