using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillar : MonoBehaviour
{   
    GameObject special;
    void Awake(){
        special = transform.parent.gameObject;
    }
    void OnEnable(){
        StartCoroutine("Duration");
        //gameObject.transform.SetParent(special.transform, false);
    }
    void OnDisable(){
        gameObject.transform.SetParent(special.transform);
    }

    IEnumerator Duration(){
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
