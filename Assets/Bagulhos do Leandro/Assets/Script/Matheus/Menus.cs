using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    MenuReferences menuReferences;

    public ControllerButtons controller;
    public GameObject[] acessibleMenus;
    public Button[] verticalButtons;
    public Button[] horizontalButtons;
    public Button[,] buttonMatrix;
    public Button mark;
    int verticalIndex = 0;
    int horizontalIndex = 0;
    void OnEnable()
    {
        verticalIndex = 0;
        horizontalIndex = 0;
        menuReferences = transform.parent.GetComponent<MenuReferences>();
        controller = menuReferences.buttons;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(controller.p1UpInput)){
            SelectVerticalButton(-1);
        }
        if(Input.GetKeyDown(controller.p1DownInput)){
            SelectVerticalButton(1);
        }
        if(Input.GetKeyDown(controller.p1LeftInput)){

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
        
        if(horizontalIndex < 0){
            horizontalIndex = horizontalButtons.Length - 1;
        }
        if(horizontalIndex >= horizontalButtons.Length){
            horizontalIndex = 0;
        }
    }

}
