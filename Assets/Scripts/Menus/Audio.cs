using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{

    // Start is called before the first frame update

/* 1
    public AudioMixer mixer;
    */
    public Slider slider;

    public AudioSource m_MyAudioSource;
    //Value from the slider, and it converts to volume level
    float m_MySliderValue;

    void Start()
    {   /*1
        mixer.SetFloat ("volume", slider.value);
        */
        //Initiate the Slider value to half way
        m_MySliderValue = slider.value;
        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        //Play the AudioClip attached to the AudioSource on startup
        m_MyAudioSource.Play();
    }

    // Update is called once per frame
     
    void Update()
    {
        m_MySliderValue = slider.value;
        m_MyAudioSource.volume = m_MySliderValue;
    }
    
 
}
