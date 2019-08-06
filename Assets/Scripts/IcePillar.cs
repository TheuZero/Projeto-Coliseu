using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillar : MonoBehaviour
{   
    public float duration = 3;
    void OnEnable(){
        StartCoroutine("Duration");
        //gameObject.transform.SetParent(special.transform, false);
    }
    void OnDisable(){
        //gameObject.transform.SetParent(special.transform);
    }

    IEnumerator Duration(){
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
