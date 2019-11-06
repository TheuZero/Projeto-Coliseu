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
    
}
