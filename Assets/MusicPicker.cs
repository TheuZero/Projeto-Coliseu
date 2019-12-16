using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPicker : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] musics;
    public float volume = 1f;
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        audioSource.clip = musics[scene.buildIndex];
        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
    void VolumeChanger(float vol){
        volume = vol;
        audioSource.volume = volume;
    }
}
