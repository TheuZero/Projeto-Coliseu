using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputOrganizer : MonoBehaviour
{
    public List<int> CommandList = new List<int>();
    public float maxFlushTimer = 0.33f;
    public float flushTimer = maxFlushTimer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void InputCommand(int command){
        CommandList.Add(command);
    }
}

public static class InputValues{
    float move = 0;
    float dash = 1;
    float jump = 2;
    float attack = 10;
    float fAttack = 11;
    float dAttack = 12;
    float upAttack = 13;

    //montar uma lista de valores para cada tipo de ataque, especialmente se eles dependerem de dois botões simultaneamente.
    //montar uma comparação de valores recebidos dos input com os da classe e reagir de acordo no InputOrganizer, assim que for possível completar, tirar da lista,
    //caso contrário, esperar o tempo antes de zerar
    //Talvez manter somente dois elementos, fazer o tempo resetar somente quando o Input for concluído, caso contrário, remover o resto da lista.
}
