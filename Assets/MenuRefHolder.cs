using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRefHolder : MonoBehaviour
{
    public ControllerButtons buttons;
    void Start()
    {
        buttons = GameObject.Find("Forward Data").GetComponent<ControllerButtons>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
