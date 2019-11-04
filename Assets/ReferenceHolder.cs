using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceHolder : MonoBehaviour
{
    public GameObject[] hpBars;
    public GameObject[] players;
    public List<IHpNotifier> hpNotifiers = new List<IHpNotifier>();
    public List<IHpListener> hpListeners = new List<IHpListener>();
    
    float temporaryHp = 30;

    void Awake()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        hpBars = GameObject.FindGameObjectsWithTag("HpBar");
        
        for(int i = 0; i < hpBars.Length; i++){
            hpListeners.Add(hpBars[i].GetComponent<HpBarBehaviour>());
        }
        
        for(int i = 0; i < players.Length; i++){
            hpNotifiers.Add(players[i].GetComponent<Status>());
        }

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

    
    void Update()
    {
        if(Input.GetKeyDown("q")){
            hpListeners[0].OnHpChange(temporaryHp--, 30, 0);
        }
    }
}
