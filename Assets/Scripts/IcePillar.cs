using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillar : MonoBehaviour
{   
    GameObject special;
    public AttackInfo attackInfo;

    
    void Awake(){
        special = transform.parent.gameObject;
        attackInfo = new AttackInfo();
        SetAttack();
    }
    void OnEnable(){
        StartCoroutine("Duration");
        //gameObject.transform.SetParent(special.transform, false);
    }
    void OnDisable(){
        gameObject.transform.SetParent(special.transform);
    }
    void SetAttack(){
        attackInfo.hitstun = 2;
        attackInfo.damage = 5;
        attackInfo.knockback = 8;
        attackInfo.knockbackDuration = 0.5f;
        attackInfo.knockup = 4.4f;
        attackInfo.knockupDuration = 0.25f;
    }
    public void FlipSide(){
        attackInfo.side = transform.localScale.x;
    }
    IEnumerator Duration(){
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
