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
    public void TakeDamage(float damage, float hitstun){
        defense.Damaged(damage, hitstun);
        Debug.Log(parent.name + "Has taken " + damage + " damage and " + hitstun + " hitstun");
    }
}
