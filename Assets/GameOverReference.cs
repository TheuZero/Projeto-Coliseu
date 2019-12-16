using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverReference : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    float updateTimer = 0.4f;
    bool updating = false;
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator textUpdate(){
        updateTimer = 0.4f;
        updating = true;
        yield return new WaitForSeconds(updateTimer);
        updating = false;
        yield break;
    }
}

public static class GeneralText{
    
}
