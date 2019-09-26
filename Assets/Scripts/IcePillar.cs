using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillar : MonoBehaviour
{   
    public float duration = 3;
    GameObject player;
    float side;
    void Awake(){
        player = transform.parent.transform.parent.GetChild(0).gameObject;
    }
    void OnEnable(){
        SpawnReference();
        StartCoroutine("Duration");
    }
    void OnDisable(){
        //gameObject.transform.SetParent(special.transform);
    }

    void SpawnReference(){
        Vector2 pillarSize = transform.localScale;
        side = player.transform.localScale.x * (Mathf.Abs(pillarSize.x));
        gameObject.transform.position = new Vector2(player.transform.position.x + side * 0.8f, player.transform.position.y + (pillarSize.y * 1.24f) * 0.12f);
        gameObject.transform.localScale = new Vector2(side, gameObject.transform.localScale.y);
    }
    IEnumerator Duration(){
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
