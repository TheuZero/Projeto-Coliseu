using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class SingleGlobalData : MonoBehaviour
{
    static SingleGlobalData self;
    CharacterManager characters;
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        if(self == null){
            self = this;
            DontDestroyOnLoad(this.gameObject);
        }/*else{
            try{
            characters.instantiatedPlayer = new List<GameObject>();
            Score.score = 0;
            Score.killNumber = 0;
            DestroyImmediate(this.gameObject);
            }catch(Exception e){
                DestroyImmediate(this.gameObject);
            }
        }*/

    }
    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(scene.buildIndex == 0){
            DestroyImmediate(this.gameObject);
        }
    }
}
