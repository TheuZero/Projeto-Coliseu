using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceHolder : MonoBehaviour
{
    public GameObject[] hpBars;
    public GameObject[] players;
    public List<IHpNotifier> hpNotifiers = new List<IHpNotifier>();
    public List<IHpListener> hpListeners = new List<IHpListener>();
    void Start()
    {
        hpListeners.Add(GameObject.FindGameObjectWithTag("HpBar").GetComponent<HpBarBehaviour>());
        hpNotifiers.Add(GameObject.Find("Riki").GetComponent<Status>());
        PassListenerList(hpListeners);
    }
    void PassListenerList(List<IHpListener> listeners){
        foreach(IHpListener listener in listeners){
            hpNotifiers[0].AttachHpListeners(listener);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //hpListeners[0].OnHpChange(15, 30, 0);
    }
}
