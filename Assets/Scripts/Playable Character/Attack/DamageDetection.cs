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
        defense = parent.transform.parent.transform.parent.GetComponent<Defense>();
    }
    public void TakeDamage(AttackInfo attackInfo){
        defense.Damaged(attackInfo);
        Debug.Log(parent.name + "Has taken " + attackInfo.damage + " damage, " + attackInfo.hitstun + " hitstun, " + attackInfo.hitlag + " hitlag");
        Debug.Log("and" + attackInfo.knockback + "knock back and " + attackInfo.knockup);
    }
    public void Grabbed(Vector3 position, bool grabbed, float side){
        defense.Grabbed(position, grabbed, side);
    }
}
