using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBox : MonoBehaviour
{
    GameObject player;
    RikiAttackController controller;
    float grabTimer = 0;
    void Start(){
        player = transform.parent.transform.parent.transform.parent.gameObject;
        controller = player.GetComponent<RikiAttackController>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            controller.isGrabbing = true;
            //StartCoroutine(GrabDuration());
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            col.gameObject.GetComponent<DamageDetection>().Grabbed(transform.position, true, Mathf.Sign(player.transform.localScale.x));
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            col.gameObject.GetComponent<DamageDetection>().Grabbed(transform.position, false, Mathf.Sign(player.transform.localScale.x));
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
