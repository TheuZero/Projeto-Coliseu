using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HpPortrait : MonoBehaviour
{
    public int index = 0;
    public Image imagePortrait;
    public Sprite[] portraits;
    public CharacterManager characterManager;
    void OnEnable()
    {
        imagePortrait = GetComponent<Image>();
        try{
        characterManager = GameObject.Find("Character Data Manager").GetComponent<CharacterManager>();
        imagePortrait.sprite = portraits[characterManager.playerCharacter[index]];
        }catch(Exception e){

        }
    }

    // Update is called once per frame
    void Update()
    {
        imagePortrait.sprite = portraits[characterManager.playerCharacter[index]];
    }
}
