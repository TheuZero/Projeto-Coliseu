using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineTracker : MonoBehaviour
{
    public CinemachineTargetGroup cinemachine;
    void Start()
    {
        cinemachine = GetComponent<CinemachineTargetGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cinemachine);
    }
}
