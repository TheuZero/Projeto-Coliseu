using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public ControllerButtons buttons;
    public Slider slider;
    public AudioSource audio;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(buttons.p1LeftInput)){
            slider.value -= 0.1f;
            audio.volume -= 0.1f;
        }
        if(Input.GetKey(buttons.p1RightInput)){
            slider.value += 0.1f;
            audio.volume += 0.1f;
        }
    }
}
