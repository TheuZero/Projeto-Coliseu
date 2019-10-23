using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    //public List<GameObject> players = new List<GameObject>();
    public GameObject[] players;
    Vector3[] playersRelativeCamPos;
    public float yDifference = 0.7f;
    
    Camera mainCam;
    public float defaultCameraSize = 2.5f;
    public float maxCameraSize = 5f;
    void Start()
    {
        /*while(GameObject.FindGameObjectWithTag("Player") != null){
            players.Add(GameObject.FindGameObjectWithTag("Player"));
        }*/
        players = GameObject.FindGameObjectsWithTag("Player");
        playersRelativeCamPos = new Vector3[players.Length];
        mainCam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        UpdateCameraByPlayerNum();
    }
    void UpdateCameraByPlayerNum(){
        GetRelativeCameraPos();
        if(players.Length == 1){
            transform.position = new Vector3(players[0].transform.position.x, players[0].transform.position.y + yDifference, -10);
        }else if(players.Length == 2){
            transform.position = new Vector3((players[0].transform.position.x + players[1].transform.position.x)/2, players[0].transform.position.y + yDifference, -10); 
            Debug.Log(playersRelativeCamPos[1].x);
           
            /*if(playersRelativeCamPos[0].x > 0.9f || playersRelativeCamPos[1].x > 0.9f){
                mainCam.orthographicSize += Time.deltaTime * 4; 
            }
            if(playersRelativeCamPos[1].x > 0.9f){
                mainCam.orthographicSize += Time.deltaTime * 4; 
            }
            if(mainCam.orthographicSize > defaultCameraSize){
                if(playersRelativeCamPos[0].x < 0.80f){
                    mainCam.orthographicSize -= Time.deltaTime * 4;
                }
                if(playersRelativeCamPos[1].x < 0.80f){
                    mainCam.orthographicSize -= Time.deltaTime * 4;
                }
            }
            if(mainCam.orthographicSize < defaultCameraSize){
                mainCam.orthographicSize = defaultCameraSize;
            }*/
        }
    }
    void GetRelativeCameraPos(){
        for(int i = 0; i < players.Length; i++){
            playersRelativeCamPos[i] = Camera.main.WorldToViewportPoint(players[i].transform.position);
        }
    }
}
