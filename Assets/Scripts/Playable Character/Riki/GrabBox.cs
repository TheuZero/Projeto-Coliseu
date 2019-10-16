using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBox : MonoBehaviour
{
    RikiAttackController controller;
    float grabTimer = 0;
    void Start(){
        controller = transform.parent.transform.parent.transform.parent.GetComponent<RikiAttackController>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            controller.isGrabbing = true;
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            col.gameObject.GetComponent<DamageDetection>().Grabbed(transform.position, true);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            col.gameObject.GetComponent<DamageDetection>().Grabbed(transform.position, false);
            controller.isGrabbing = false;
        }
    }

    IEnumerator GrabDuration(){
        grabTimer = 2f;
        while(grabTimer > 0){
            grabTimer -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        controller.isGrabbing = false;
        yield break;
    }
}
