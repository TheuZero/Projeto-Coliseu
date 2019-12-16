using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    // Start is called before the first frame update
        GameObject player;
    CauboiAttackController controller;
    float grabTimer = 0;
    void Start(){
        player = transform.parent.transform.parent.transform.parent.gameObject;
        controller = player.GetComponent<CauboiAttackController>();
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            controller.isGrabbing = true;
            grabTimer = 2f;
            Debug.Log("Agarrou");
        }
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            col.gameObject.GetComponent<DamageDetection>().Grabbed(transform.position, true, Mathf.Sign(player.transform.localScale.x));
            controller.isGrabbing = true;
            GrabDuration(col);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Hurt Box"){
            col.gameObject.GetComponent<DamageDetection>().Grabbed(transform.position, false, Mathf.Sign(player.transform.localScale.x));
            controller.isGrabbing = false;
            Debug.Log("saiu");
        }
    }

    void GrabDuration(Collider2D col){
        if(grabTimer > 0){
            grabTimer -= Time.deltaTime;
        }else{
            col.gameObject.GetComponent<DamageDetection>().GrabCancel();
            controller.isGrabbing = false;
        }
    }
}
