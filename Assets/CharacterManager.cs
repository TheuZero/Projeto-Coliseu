using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterManager : MonoBehaviour
{
    public ControllerButtons buttons;
    public GameObject[] characters;
    public Dictionary<int, GameObject> assignedCharacter = new Dictionary<int, GameObject>();
    public GameObject[] toSpawn;
    public List<GameObject> instantiatedPlayer = new List<GameObject>();
    void Start()
    {

    }

    public void SetSpawnCharacter(int playerNum, int playerChar){
        assignedCharacter.Remove(playerNum);
        assignedCharacter.Add (playerNum, characters[playerChar]);
    }
    public void RemoveSpawnCharacter(int playerNum){
        assignedCharacter.Remove(playerNum);
    }
    public void Spawn(Transform transform){
        toSpawn = assignedCharacter.Values.ToArray();       
        for(int i = 0; i < toSpawn.Length; i++){
            instantiatedPlayer.Add(Instantiate(toSpawn[i], new Vector3(5 * (i * 2),0,0), Quaternion.identity, transform));
        }
        for(int i = 0; i < instantiatedPlayer.Count; i++){
            instantiatedPlayer[i].transform.GetChild(0).GetComponent<Status>().playerNumber = i;
            instantiatedPlayer[i].transform.GetChild(0).GetComponent<Controller>().SetCommands(buttons, i);
        }   
    }
    void Update(){
        if(Input.GetKey("q")){
            Spawn(gameObject.transform);
        }
    }
}