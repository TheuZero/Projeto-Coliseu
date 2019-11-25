using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    Text texto;
    float updateTimer = 0.4f;
    bool updating = false;
    void Start(){
        texto = GetComponent<Text>();
    }
    void Update()
    {
        if(!updating){
            StartCoroutine(textUpdate());
        }
    }
    IEnumerator textUpdate(){
        updating = true;
        yield return new WaitForSeconds(updateTimer);
        texto.text = Score.score.ToString();
        updating = false;
        yield break;
    }
}
