﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterSelector : MonoBehaviour
{
    public GameObject initialMenu;
    public GameModeManager gameMode;
    public GameObject pvp;
    public GameObject arcade;
    GameObject actualScreen;
    public Button[] buttons;
    public ControllerButtons controller;
    public GameObject[] cursor;
    public GameObject[] cursorConfirm;
    public CharacterManager characterManager;
    public GameObject[] selectedCharacter;
    
    public int playerNum = 2;
    int[] playerIndex;
    public bool[] playerControlEnabled;
    public bool p2Selected = false;
    public bool p2Active = true;

    int sceneIndex;

    void Start(){
        actualScreen = gameObject;
        gameMode = GameObject.Find("Game Mode Manager").GetComponent<GameModeManager>();
        playerIndex = new int[playerNum];
        playerControlEnabled = new bool[playerNum];
        for(int i = 0; i < playerControlEnabled.Length; i++){
            playerControlEnabled[i] = true;
        }        
        DisablePlayer(1);
    }
    void OnEnable(){
        for(int i = 0; i < 2; i++){
            selectedCharacter[i].GetComponent<Image>().enabled = false;
        }
        actualScreen = gameObject;
        if(actualScreen == arcade){
            gameMode.currentGameMode = GameModeManager.GameMode.Arcade;
            sceneIndex = 1;
            //DisablePlayer(1);
        }else{
            gameMode.currentGameMode = GameModeManager.GameMode.PVP;
            sceneIndex = 2;
            //EnablePlayer(1);
        }
    }
    void Update(){
        if(playerControlEnabled[0]){
            if(Input.GetKeyDown(controller.p1LeftInput)){
                SelectButton(0,-1);
                Debug.Log(playerIndex[0]);
            }
            if(Input.GetKeyDown(controller.p1RightInput)){
                SelectButton(0,1);
                Debug.Log(playerIndex[0]);
            }
            if(Input.GetKeyDown(controller.p1AttackInput)){
                Confirm(0);
                SetSelectedImage(0, playerIndex[0]);
                characterManager.SetSpawnCharacter(0, playerIndex[0]);
            }
            if(Input.GetKeyDown(controller.p1TechInput)){
                Cancel(0);
            }
        }else{
            if(Input.GetKeyDown(controller.p1AttackInput)){
                StartGame(sceneIndex);
            }
            if(Input.GetKeyDown(controller.p1TechInput)){
                Cancel(0);
                RemoveSelectedImage(0);
                characterManager.RemoveSpawnCharacter(0);
            }
        }

        if(playerControlEnabled[1]){
            if(Input.GetKeyDown(controller.p2LeftInput)){
                SelectButton(1,-1);
            }
            if(Input.GetKeyDown(controller.p2RightInput)){
                SelectButton(1,1);
            }
            if(Input.GetKeyDown(controller.p2AttackInput)){
                Confirm(1);
                SetSelectedImage(1, playerIndex[1]);
                characterManager.SetSpawnCharacter(1, playerIndex[1]);
            }
            if(Input.GetKeyDown(controller.p2TechInput)){
                Cancel(1);
            }
        }else{
            if(Input.GetKeyDown(controller.p2AttackInput)){
                Confirm(1);
            }
            if(Input.GetKeyDown(controller.p2TechInput)){
                Cancel(1);
                RemoveSelectedImage(1);
                characterManager.RemoveSpawnCharacter(1);
            }
        }
    }

    void SelectButton(int playerNum, int direction){
        playerIndex[playerNum] += direction;
        playerIndex[playerNum] = IndexLimiter(playerIndex[playerNum]);
        HighLightButtons(playerNum);
    }

    int IndexLimiter(int index){
        if(index >= buttons.Length){
            return 0;
        }
        if(index < 0){
            return buttons.Length - 1;
        }else{
            return index;
        }
    }

    void HighLightButtons(int playerNum){
        cursor[playerNum].transform.localPosition = new Vector3 (buttons[playerIndex[playerNum]].transform.localPosition.x - 64f,
        buttons[playerIndex[playerNum]].transform.localPosition.y + 46f - (playerNum * 46f), buttons[playerIndex[playerNum]].transform.localPosition.z);

        buttons[playerIndex[playerNum]].Select();
        buttons[playerIndex[playerNum]].OnSelect(null);
        
    }
    void Confirm(int playerNum){
        if(playerNum > 0 && !p2Active){
            EnablePlayer(playerNum);
        }else{
            cursorConfirm[playerNum].transform.localPosition = buttons[playerIndex[playerNum]].transform.localPosition;
            playerControlEnabled[playerNum] = false;
        }
    }
    void EnablePlayer(int playerNum){
        playerControlEnabled[playerNum] = true;
        HighLightButtons(playerNum);
        p2Active = true;
    }

    void Cancel(int playerNum){
        if(playerNum > 0 && playerControlEnabled[playerNum]){
            DisablePlayer(playerNum);
        }else{
            if(playerControlEnabled[playerNum]){
                initialMenu.SetActive(true);
                gameObject.SetActive(false);
            }
            playerControlEnabled[playerNum] = true;
            cursorConfirm[playerNum].transform.localPosition = new Vector2(10000,10000);
        }
    }
    void DisablePlayer(int playerNum){
        if(playerControlEnabled[playerNum]){
            playerControlEnabled[playerNum] = false;
            cursor[playerNum].transform.localPosition = new Vector2(10000,10000);
            p2Active = false;
        }
    }

    public void GoToMenuScreen(GameObject go){
        go.SetActive(true);
        Reset();
        gameObject.SetActive(false);

    }
    void Reset(){
        for(int i = 0; i < playerIndex.Length; i++){
            playerIndex[i] = 0;
        }
    }
    void StartGame(int sceneIndex){
        if(CanStart())
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    bool CanStart(){
        if(gameMode.currentGameMode == GameModeManager.GameMode.PVP && p2Active){
            if(!playerControlEnabled[0] && !playerControlEnabled[1]){
                return true;
            }
        }else if(gameMode.currentGameMode == GameModeManager.GameMode.Arcade){
            if(!playerControlEnabled[0] && !playerControlEnabled[1]){
                return true;
            }
            if(!playerControlEnabled[0] && !p2Active){
                return true;
            }
        }
        return false;
    }

    public void SetSelectedImage(int playerNum, int charNum){
        selectedCharacter[playerNum].GetComponent<Image>().enabled = true;
        selectedCharacter[playerNum].GetComponent<Image>().sprite = buttons[charNum].GetComponent<Image>().sprite;
    }

    public void RemoveSelectedImage(int playerNum){
        selectedCharacter[playerNum].GetComponent<Image>().enabled = false;
    }

}
