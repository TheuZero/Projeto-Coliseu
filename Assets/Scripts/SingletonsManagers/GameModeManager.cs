using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public enum GameMode{
        PVP,
        Arcade
    }
    public GameMode currentGameMode;
    string finalMessage;

    public int playersAlive = 0;
    void PlayerDead(int playerNum){
        playersAlive--;
        if(playersAlive <= 0 && currentGameMode == GameModeManager.GameMode.Arcade){
            finalMessage = "Você fez "+ Score.score + " pontos";
        }else if(playersAlive == 1 && currentGameMode == GameModeManager.GameMode.PVP){
            finalMessage = "Fim de jogo, jogador " + (playerNum + 1) + " venceu";
        }
    }    
}
