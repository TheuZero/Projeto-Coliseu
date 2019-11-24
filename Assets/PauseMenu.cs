using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable(){
        Time.timeScale = 0;
    }
    void OnDisable(){
        Time.timeScale = 1f;
    }

    
    public void GoToScene(int sceneIndex){
        if(sceneIndex == 0){
            Score.score = 0;
        }
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
    public void DisablePause(){
        this.gameObject.SetActive(false);
    }
}
