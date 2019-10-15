using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBox : MonoBehaviour
{
    
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            col.gameObject.GetComponent<DamageDetection>().Grabbed(transform.position, true);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            col.gameObject.GetComponent<DamageDetection>().Grabbed(transform.position, false);
        }
    }
}
