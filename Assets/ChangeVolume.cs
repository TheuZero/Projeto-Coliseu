using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public ControllerButtons buttons;
    Slider slider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(buttons.p1LeftInput)){
            slider.value -= 1;
        }
        if(Input.GetKey(buttons.p1LeftInput)){
            slider.value += 1;
        }
    }
}
