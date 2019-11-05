using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterSelector : MonoBehaviour
{
    public Button[] buttons;
    public ControllerButtons controller;
    public GameObject[] cursor;
    public GameObject[] cursorConfirm;
    public CharacterManager characterManager;
    public int playerNum = 2;
    int[] playerIndex;
    bool[] playerControlEnabled;

    void Start(){
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
                characterManager.SetCurrentPlayer(0);
                buttons[playerIndex[0]].onClick.Invoke();
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
                characterManager.SetCurrentPlayer(0);
                buttons[playerIndex[1]].onClick.Invoke();
            }
        }
    }

    void SelectButton(int playerNum, int direction){
        playerIndex[playerNum] += direction;
        playerIndex[playerNum] = IndexLimiter(playerIndex[playerNum]);
        HighLightButtons();
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

    void HighLightButtons(){
        for(int i = 0; i < playerNum; i++){
            cursor[i].transform.localPosition = new Vector3 (buttons[playerIndex[i]].transform.localPosition.x,
            buttons[playerIndex[i]].transform.localPosition.y - 134.5f - (i * 85f), buttons[playerIndex[i]].transform.localPosition.z);

            buttons[playerIndex[i]].Select();
            buttons[playerIndex[i]].OnSelect(null);
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
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

}
