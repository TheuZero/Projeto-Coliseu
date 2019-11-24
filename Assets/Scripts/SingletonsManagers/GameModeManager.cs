using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public enum GameMode{
        PVP,
        Arcade
    }
    public GameMode currentGameMode;
    string finalMessage;
    public ReferenceHolder referenceHolder;
    public TextMeshProUGUI text;

    public int playersAlive = 0;

    void Start(){

    }

    public void PlayerDead(int playerNum){
        playersAlive--;
        
        if(referenceHolder == null){
            referenceHolder = GameObject.Find("Reference Master").GetComponent<ReferenceHolder>();
        }

        if(playersAlive <= 0 && currentGameMode == GameModeManager.GameMode.Arcade){
            text = referenceHolder.gameOverText;
            text.gameObject.SetActive(true);
            finalMessage = "Você fez "+ Score.score + " pontos";
            text.text = finalMessage;
            Score.score = 0;
            StartCoroutine(BackToMenu());
        }else if(playersAlive == 1 && currentGameMode == GameModeManager.GameMode.PVP){
            text = referenceHolder.gameOverText;
            text.gameObject.SetActive(true);
            finalMessage = "Fim de jogo, jogador " + (playerNum) + " venceu";
            text.text = finalMessage;
            StartCoroutine(BackToMenu());
        }
        
        
    }

    void Update(){
        if(Input.GetKeyDown("q")){
            
        }
    }
    IEnumerator BackToMenu(){
        float timer = 3f;
        while(timer > 0){
            timer -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        yield break;
    }

}
