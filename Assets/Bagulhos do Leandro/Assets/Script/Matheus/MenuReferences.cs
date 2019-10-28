using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuReferences : MonoBehaviour
{
    public enum menusIndexes{
        initial = 0,
        arcade = 1,
        pvp = 2,
        configMenu = 3,
        controllerConfig = 4,
        videoConfig = 5,
        audioConfig = 6
    }
    public ControllerButtons buttons;
    public GameObject[] menus;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
