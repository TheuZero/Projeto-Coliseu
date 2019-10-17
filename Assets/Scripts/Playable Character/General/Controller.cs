using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    int attackCommand = InputValues.attack;
    int specialCommand = InputValues.nSpecial;
    int jumpCommand = InputValues.jump;
    int techCommand = InputValues.tech;

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
        if(Input.GetButton("Attack")){
            input.InputCommand(attackCommand, InputType.hold);
        }
        if(Input.GetButtonUp("Attack")){
			input.InputCommand(attackCommand, InputType.up);
		}
        if(Input.GetButtonDown("Special")){
            input.InputCommand(specialCommand, InputType.down);
        }
        if(Input.GetButton("Special")){
            input.InputCommand(specialCommand, InputType.hold);
        }
        if(Input.GetButtonDown("Tech")){
            input.InputCommand(techCommand, InputType.down);
        }
        if(Input.GetButton("Tech")){
            input.InputCommand(techCommand, InputType.hold);
        }
        if(Input.GetButtonUp("Tech")){
			input.InputCommand(techCommand, InputType.up);
		}
        if(Input.GetButtonDown("Jump")){
			input.InputCommand(jumpCommand, InputType.down);
		}
        if(Input.GetButton("Jump")){
            //input.InputCommand(jumpCommand, InputType.hold);
        }
		if(Input.GetButtonUp("Jump")){
			input.InputCommand(jumpCommand, InputType.up);
		}
    }
    
}