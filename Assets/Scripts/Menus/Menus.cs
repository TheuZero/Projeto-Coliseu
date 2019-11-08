using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    public enum Orientation{
        vertical,
        horizontal
    }
    MenuReferences menuReferences;
    public ControllerButtons controller;
    public Button[] verticalButtons;
    public Orientation orientation;
    //public Button[] horizontalButtons;
    //public Button[,] buttonMatrix;
    public Button mark;
    int verticalIndex = 0;
    //int horizontalIndex = 0;
    void OnEnable()
    {
        verticalIndex = 0;
        HighLightVerticalButtons();
        menuReferences = transform.parent.GetComponent<MenuReferences>();
        //controller = menuReferences.buttons;
        controller = GameObject.Find("Forward Data").GetComponent<ControllerButtons>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(orientation == Orientation.vertical){
            if(Input.GetKeyDown(controller.p1UpInput)){
                SelectVerticalButton(-1);
            }
            if(Input.GetKeyDown(controller.p1DownInput)){
                SelectVerticalButton(1);
            }
        }else{
            if(Input.GetKeyDown(controller.p1LeftInput)){
                SelectVerticalButton(-1);
            }
            if(Input.GetKeyDown(controller.p1RightInput)){
                SelectVerticalButton(1);
            }
        }
        /*if(Input.GetKeyDown(controller.p1LeftInput)){

        }*/
        if(Input.GetKeyDown(controller.p1AttackInput)){
            verticalButtons[verticalIndex].onClick.Invoke();
        }
    }
    void SelectVerticalButton(int index){
        verticalIndex += index;
        HighLightVerticalButtons();
    }
    void HighLightVerticalButtons(){
        IndexLimiter();
        mark.transform.localPosition = new Vector3 
        (verticalButtons[verticalIndex].transform.localPosition.x - 109.9f, 
        verticalButtons[verticalIndex].transform.localPosition.y,0);

        verticalButtons[verticalIndex].Select();
        verticalButtons[verticalIndex].OnSelect(null);
    }
    void IndexLimiter(){
        if(verticalIndex < 0){
            verticalIndex = verticalButtons.Length - 1;
        }
        if(verticalIndex >= verticalButtons.Length){
            verticalIndex = 0;
        }
        
        /*if(horizontalIndex < 0){
            horizontalIndex = horizontalButtons.Length - 1;
        }
        if(horizontalIndex >= horizontalButtons.Length){
            horizontalIndex = 0;
        }*/
    }

    public void GoToMenuScreen(GameObject tela){
        tela.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Exit(){
        Application.Quit();
    }


}
