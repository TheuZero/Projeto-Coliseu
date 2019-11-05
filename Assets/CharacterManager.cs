using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    public List<GameObject> toSpawn = new List<GameObject>();
    public List<GameObject> instantiatedPlayer = new List<GameObject>();
    public int playerNumber = 2;
    public int currentPlayer;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetCurrentPlayer(int playerNum){
        currentPlayer = playerNum;
    }
    public void SetSpawnCharacter(int playerChar){
        toSpawn[playerNumber] = characters[playerChar];
    }
    public void Spawn(){
        for(int i = 0; i < toSpawn.Count; i++){
            instantiatedPlayer.Add(Instantiate(toSpawn[i], new Vector3(0,0,0), Quaternion.identity));
            instantiatedPlayer[i].transform.SetParent(gameObject.transform);
            instantiatedPlayer[i].transform.GetChild(0).GetComponent<Status>().playerNumber = i;
        }
    }
}