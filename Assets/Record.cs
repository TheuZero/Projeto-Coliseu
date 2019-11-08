using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    public ControllerButtons buttons;
    public GameObject initialMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(buttons.p1AttackInput)|| Input.GetKeyDown(buttons.p1TechInput)){
            initialMenu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
