using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    GameObject parent;
    Defense defense;
    void Start()
    {
        parent = transform.parent.gameObject;
        defense = parent.GetComponent<Defense>();
    }
    public void TakeDamage(AttackInfo attackInfo){
        defense.Damaged(attackInfo);
        Debug.Log(parent.name + "Has taken " + attackInfo.damage + " damage and " + attackInfo.hitstun + " hitstun");
    }
}
