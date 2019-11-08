using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGlobalData : MonoBehaviour
{
    static SingleGlobalData self;
    CharacterManager characters;
    void Start()
    {
        if(self == null){
            self = this;
            DontDestroyOnLoad(this.gameObject);
        }else{
            DestroyImmediate(this.gameObject);
            characters.instantiatedPlayer.Clear();
            Score.score = 0;
            Score.killNumber = 0;
        }
    }
}
