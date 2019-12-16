using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineTracker : MonoBehaviour
{
    public CinemachineTargetGroup cinemachine;
    public ReferenceHolder references;
    public GameObject[] players;
    public List<CinemachineTargetGroup.Target> targets = new List<CinemachineTargetGroup.Target>();

    void Start()
    {
        if(references == null){
            references = GameObject.Find("Reference Master").GetComponent<ReferenceHolder>();
        }
        cinemachine = GetComponent<CinemachineTargetGroup>();
        players = references.players;
        for(int i = 0; i < players.Length; i++){
            targets.Add(new CinemachineTargetGroup.Target { target = players[i].transform, radius = 0f, weight = 1f });
        }
        cinemachine.m_Targets = targets.ToArray();
    }
}
