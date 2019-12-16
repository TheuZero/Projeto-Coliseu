using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    public int scorePoints;
    void OnDisable(){
        Score.score += scorePoints;
        Score.killNumber++;
    }
}

public static class Score{
    public static int score = 0;
    public static int killNumber = 0;
}
