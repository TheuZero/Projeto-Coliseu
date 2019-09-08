using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    int attackCommand = InputValues.attack;
    int specialCommand = InputValues.nSpecial;
    InputOrganizer input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputOrganizer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Attack")){
			input.InputCommand(attackCommand, InputType.down);
		}
        if(Input.GetButtonDown("Special")){
            input.InputCommand(specialCommand, InputType.down);
        }
    }
    void FixedUpdate(){

    }
}
