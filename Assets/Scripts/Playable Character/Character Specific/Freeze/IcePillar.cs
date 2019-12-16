using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePillar : MonoBehaviour
{   
    public float duration = 6;
    public GameObject player;
    public float xOffset = 0;
    public float yOffset = 3f;
    float side;
    void Awake(){
        //player = transform.parent.transform.parent.GetChild(0).gameObject;
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
        gameObject.transform.position = new Vector3(player.transform.position.x + side * xOffset, player.transform.position.y + yOffset, 0);
        gameObject.transform.localScale = new Vector3(side, gameObject.transform.localScale.y, 1);
    }
    IEnumerator Duration(){
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
