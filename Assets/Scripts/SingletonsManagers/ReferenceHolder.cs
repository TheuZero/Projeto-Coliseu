using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReferenceHolder : MonoBehaviour
{
    public CharacterManager characterManager;
    public TextMeshProUGUI gameOverText;
    public GameObject[] hpUi;
    public GameObject[] hpBars;
    public GameObject[] players;
    public List<IHpNotifier> hpNotifiers = new List<IHpNotifier>();
    public List<IHpListener> hpListeners = new List<IHpListener>();
    public GameObject pauseScreen;
    float temporaryHp = 30;

    void Awake()
    {
        gameOverText = GameObject.Find("Game Over").GetComponent<TextMeshProUGUI>();
        gameOverText.gameObject.SetActive(false);
        pauseScreen = GameObject.Find("Pause Menu");
        pauseScreen.SetActive(false);
        try{
            characterManager = GameObject.Find("Character Data Manager").GetComponent<CharacterManager>();
            characterManager.Spawn(transform.GetChild(0));
            players = new GameObject[characterManager.instantiatedPlayer.Count];
            for(int i = 0; i < players.Length; i++){
                players[i] = transform.GetChild(0).transform.GetChild(i).transform.GetChild(0).gameObject;
            }
        }catch(Exception e){//players = GameObject.FindGameObjectsWithTag("Player");
            Debug.Log("Não foi encontrado dados vindo do menu" + e);
            players = GameObject.FindGameObjectsWithTag("Player");
        }
        //hpBars = GameObject.FindGameObjectsWithTag("HpBar");
        for(int i = 0; i < hpBars.Length; i++){
            hpListeners.Add(hpBars[i].GetComponent<HpBarBehaviour>());
        }
        
        for(int i = 0; i < players.Length; i++){
            hpNotifiers.Add(players[i].GetComponent<Status>());
            hpUi[i].SetActive(true);
        }

        EnableHpBars(players);
        PassListenerList(hpListeners);
    }
    void PassListenerList(List<IHpListener> listeners){
        /*foreach(IHpListener listener in listeners){
            hpNotifiers[0].AttachHpListeners(listener);
        }*/
        for(int i = 0; i < hpNotifiers.Count; i++){
            hpNotifiers[i].AttachHpListeners(hpListeners[i]);
        }
    }

    void EnableHpBars(GameObject[] players){
        for(int i = 0; i < players.Length; i++){
            hpBars[i].SetActive(true);
        }
    }
}
