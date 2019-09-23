using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOrganizer : MonoBehaviour
{
    [SerializeField]
    public InputBufferItem[] buffer = new InputBufferItem[12];
    public InputBufferItem[] aux = new InputBufferItem[12];
    public float maxFlushTimer = 0.33f;
    public float flushTimer = 0;


    public int commandAux = 11;

//    Animator anim;
//    MovementController movement;
//    Status status;
    StateManager state;


    string tst;
    void Start()
    {
        for(int i = 0; i < buffer.Length; i++){
            buffer[i] = new InputBufferItem();
            aux[i] = new InputBufferItem();
        }
//        anim = GetComponent<Animator>();
//        movement = GetComponent<MovementController>();
//        status = GetComponent<Status>();
        state = GetComponent<StateManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FlushBuffer();
        CheckCommand();
    }

    void LateUpdate(){
        
        if(Input.GetKeyDown("1")){
            tst = "";
            for(int i = 0; i < buffer.Length - 1; i++){
                tst += "o buffer da posicao " + i + " o comando é de valor " + buffer[i].command + " está em " + buffer[i].used + "\n";
            }
            Debug.Log(tst);
        }
        if(Input.GetKeyDown("2")){
            tst = "";
            for(int i = 0; i < aux.Length - 1; i++){
                tst += "o buffer aux da posicao " + i + " o comando é de valor " + aux[i].command + " está em " + aux[i].used + "\n";
            }
            Debug.Log(tst);
        }
    }

    public void InputCommand(int command, int type){
        for (int i = 0; i < aux.Length; i++){
            aux[i].command = buffer[i].command;
            aux[i].used = buffer[i].used;
            aux[i].type = buffer[i].type ;
        }
        buffer[0].command = command;
        buffer[0].used = false;
        buffer[0].type = type;
        for (int i = 1; i < buffer.Length; i ++){
            buffer[i].command = aux[i - 1].command;
            buffer[i].used = aux[i - 1].used;
            buffer[i].type = aux[i - 1].type ;
        }
        commandAux = 11;
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
        for(int i = buffer.Length - 1; i >= 0; i--){
            if(!buffer[i].used){
                if(Execute(buffer[i].command, buffer[i].type)){
                    buffer[i].used = true;
                }
                break;
            }
        }
    }
    
    /*private void CheckCommand(){
        if(buffer[commandAux].used){
            commandAux--;
        }else{
            buffer[commandAux].used = Execute(buffer[commandAux].command, buffer[commandAux].type);
        }
        if(commandAux <= 0){
            commandAux = 11;
        }
    }*/

    private bool Execute(int command, int type){
        //bool confirm = false;

        /*
        if(command == 0){
            confirm = true;
        }
        if(command == InputValues.moveX){

        }
        if(command == InputValues.jump){
            if(type == InputType.down){
                confirm = movement.JumpCheck();
            }
            else if(type == InputType.up){
                confirm = movement.JumpEnd();
            }
        }
        if(command == InputValues.attack){
            if(type == InputType.down){
                confirm = state.AttackDown();
            }
        }
        if(command == InputValues.nSpecial){
            confirm = state.SpecialDown();
        }
        if(confirm){
            flushTimer = 0;
        }
        */
        return state.WasExecuted(command, type);
    }
}

public class InputBufferItem{
    public InputBufferItem(){
        command = 0;
        used = false;
        type = 0;
    }
    public int command = 0;
    public bool used = false;
    public int type;
}
static class InputValues{
    public static int none = 0;
    public static int moveX = 1;
//    public static int dash = 1;
    public static int jump = 2;
    public static int attack = 3;
    public static int nSpecial = 4;
    public static int moveY = 5;

    //montar uma lista de valores para cada tipo de ataque, especialmente se eles dependerem de dois botões simultaneamente.
    //montar uma comparação de valores recebidos dos input com os da classe e reagir de acordo no InputOrganizer, assim que for possível completar, tirar da lista,
    //caso contrário, esperar o tempo antes de zerar
    //Talvez manter somente dois elementos, fazer o tempo resetar somente quando o Input for concluído, caso contrário, remover o resto da lista.
}

//colocar o resto dos botões o input buffer, tanto o aperto, segurar e soltar
static class InputType{
    public static int none = 0;
    public static int down = 1;
    public static int hold = 2;
    public static int up = 3;
}

//para fazer movimentos que precisam de mais de um botão para sair, seria bom mandar a lista do buffer atual como parametro
//para o comando e ele fazer todas as verificações necessárias antes de escolher a ação para ser executada