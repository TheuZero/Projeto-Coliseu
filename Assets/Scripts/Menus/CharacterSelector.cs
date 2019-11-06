using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterSelector : MonoBehaviour
{
    public GameModeManager gameMode;
    public GameObject pvp;
    public GameObject arcade;
    GameObject actualScreen;
    public Button[] buttons;
    public ControllerButtons controller;
    public GameObject[] cursor;
    public GameObject[] cursorConfirm;
    public CharacterManager characterManager;
    
    public int playerNum = 2;
    int[] playerIndex;
    bool[] playerControlEnabled;
    bool p2Selected = false;
    bool p2Active = true;

    void Start(){
        actualScreen = gameObject;
        if(actualScreen == arcade){

        }else if(actualScreen == pvp){
            
        }
        playerIndex = new int[playerNum];
        playerControlEnabled = new bool[playerNum];
        for(int i = 0; i < playerControlEnabled.Length; i++){
            playerControlEnabled[i] = true;
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
                characterManager.SetSpawnCharacter(0, playerIndex[0]);
            }
            if(Input.GetKeyDown(controller.p1TechInput)){
                Cancel(0);
            }
        }else{
            if(Input.GetKeyDown(controller.p1AttackInput)){
                StartGame(1);
            }
            if(Input.GetKeyDown(controller.p1TechInput)){
                Cancel(0);
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
                characterManager.SetSpawnCharacter(1, playerIndex[0]);
            }
            if(Input.GetKeyDown(controller.p2TechInput)){
                Cancel(1);
            }
        }else{
            if(Input.GetKeyDown(controller.p2AttackInput)){
                
            }
            if(Input.GetKeyDown(controller.p2TechInput)){
                Cancel(1);
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
        if(playerNum > 1){
            if(!playerControlEnabled[playerNum]){
                playerControlEnabled[playerNum] = true;
                HighLightButtons(playerNum);
            }
        }else{
            cursorConfirm[playerNum].transform.localPosition = buttons[playerIndex[playerNum]].transform.localPosition;
            playerControlEnabled[playerNum] = false;
        }
    }
    void Cancel(int playerNum){
        if(playerNum > 1){
            if(playerControlEnabled[playerNum]){
                playerControlEnabled[playerNum] = false;
                cursor[playerNum].transform.localPosition = new Vector2(10000,10000);
            }
        }
        playerControlEnabled[playerNum] = true;
        cursorConfirm[playerNum].transform.localPosition = new Vector2(10000,10000);
    }
    void HighLightSelectedButton(){

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
        if(!playerControlEnabled[1])
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

}
