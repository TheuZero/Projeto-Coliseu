using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpecialData", menuName = "Special Data", order = 51)]
public class SpecialData : AttackData
{
    [SerializeField]
    public float screenFreezeDuration;
    [SerializeField]
    public float mpCost;


}
