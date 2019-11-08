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
            
            characters.instantiatedPlayer = new List<GameObject>();
            Score.score = 0;
            Score.killNumber = 0;
            DestroyImmediate(this.gameObject);
        }
    }
}
