using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    //public List<GameObject> players = new List<GameObject>();
    public GameObject[] players;
    void Start()
    {
        /*while(GameObject.FindGameObjectWithTag("Player") != null){
            players.Add(GameObject.FindGameObjectWithTag("Player"));
        }*/
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void FixedUpdate()
    {
        if(players.Length == 1){
            transform.position = new Vector3(players[0].transform.position.x, players[0].transform.position.y, -10);

        }     
        Debug.Log(players[0].name);
        Debug.Log(players.Length);  
    }
}
