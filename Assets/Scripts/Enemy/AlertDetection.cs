using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertDetection : MonoBehaviour
{
    public List<GameObject> targets;
    int targetNum;
    public Alert alert;
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player")
            targets.Add(col.gameObject);
    }
    void OnTriggerStay2D(Collider2D col){
        if(col.gameObject == targets[0]){
            alert.Follow(targets[0].transform.position);
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.tag == "Player")
            targets.Remove(col.gameObject);   
    }
    
}
