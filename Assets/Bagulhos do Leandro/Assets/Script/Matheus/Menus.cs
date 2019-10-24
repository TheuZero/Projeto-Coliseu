using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    MenuReferences menuReferences;
    public ControllerButtons controller;
    public GameObject[] acessibleMenus;
    public Button[] actualButtons;
    float actualIndex;
    void OnEnable()
    {

        menuReferences = transform.parent.GetComponent<MenuReferences>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            Debug.Log(actualButtons[0].name);
        }
    }
}
