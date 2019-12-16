﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    int attackCommand = InputValues.attack;
    int specialCommand = InputValues.nSpecial;
    int jumpCommand = InputValues.jump;
    int techCommand = InputValues.tech;
    int moveXposCommand = InputValues.moveXpos;
    int moveXnegCommand = InputValues.moveXneg;
    //falta adicionar o cima baixo e defesa
    public KeyCode leftInput = KeyCode.LeftArrow;
    public KeyCode rightInput = KeyCode.RightArrow;
    public KeyCode upInput = KeyCode.UpArrow;
    public KeyCode downInput = KeyCode.DownArrow;
    public KeyCode jumpInput = KeyCode.Space;
    public KeyCode attackInput = KeyCode.Z;
    public KeyCode defendInput;
    public KeyCode specialInput = KeyCode.C;
    public KeyCode techInput = KeyCode.X;
    public KeyCode pauseInput = KeyCode.P;


    public ReferenceHolder referenceHolder;
    public GameObject pauseScreen;

    InputOrganizer input;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputOrganizer>();
        referenceHolder = GameObject.Find("Reference Master").GetComponent<ReferenceHolder>();
        pauseScreen = referenceHolder.pauseScreen;
    }
    void Update()
    {
        if(Input.GetKeyDown(attackInput)){
			input.InputCommand(attackCommand, InputType.down);
		}
        /*
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
		}*/
        if(Input.GetKey(attackInput)){
            input.InputCommand(attackCommand, InputType.hold);
        }
        if(Input.GetKeyUp(attackInput)){
			input.InputCommand(attackCommand, InputType.up);
		}
        if(Input.GetKeyDown(specialInput)){
            input.InputCommand(specialCommand, InputType.down);
        }
        if(Input.GetKey(specialInput)){
            input.InputCommand(specialCommand, InputType.hold);
        }
        if(Input.GetKeyDown(techInput)){
            input.InputCommand(techCommand, InputType.down);
        }
        if(Input.GetKey(techInput)){
            input.InputCommand(techCommand, InputType.hold);
        }
        if(Input.GetKeyUp(techInput)){
			input.InputCommand(techCommand, InputType.up);
		}
        if(Input.GetKeyDown(jumpInput)){
			input.InputCommand(jumpCommand, InputType.down);
		}
        if(Input.GetKey(jumpInput)){
            input.InputCommand(jumpCommand, InputType.hold);
        }
		if(Input.GetKeyUp(jumpInput)){
			input.InputCommand(jumpCommand, InputType.up);
		}
        if(Input.GetKeyDown(leftInput)){
            input.InputCommand(moveXnegCommand, InputType.down);
        }

        if(Input.GetKeyUp(leftInput)){
            input.InputCommand(moveXnegCommand, InputType.up);
        }
        if(Input.GetKeyDown(rightInput)){
            input.InputCommand(moveXposCommand, InputType.down);
        }

        if(Input.GetKeyUp(rightInput)){
            input.InputCommand(moveXposCommand, InputType.up);
        }
        if(Input.GetKeyDown(upInput)){

        }
        if(Input.GetKey(upInput)){
            
        }
        if(Input.GetKeyUp(upInput)){
            
        }
        if(Input.GetKeyDown(downInput)){

        }
        if(Input.GetKey(downInput)){
            
        }
        if(Input.GetKeyUp(downInput)){
            
        }
        if(Input.GetKeyDown(pauseInput)){
            pauseScreen.SetActive(true);
        }
    }

    void FixedUpdate(){
                if(Input.GetKey(rightInput)){
            input.InputCommand(moveXposCommand, InputType.hold);
        }
                if(Input.GetKey(leftInput)){
            input.InputCommand(moveXnegCommand, InputType.hold);
        }
    }
    public void SetCommands(ControllerButtons buttons, int playerNum){
        if(playerNum == 0){
            leftInput 	= buttons.p1LeftInput;
            rightInput 	= buttons.p1RightInput;
            upInput 	= buttons.p1UpInput;
            downInput 	= buttons.p1DownInput;
            jumpInput 	= buttons.p1JumpInput;
            attackInput = buttons.p1AttackInput;
            defendInput = buttons.p1DefendInput; 
            specialInput = buttons.p1SpecialInput;
            techInput 	= buttons.p1TechInput;
            pauseInput  = buttons.p1PauseInput;
        }else if(playerNum == 1){
            leftInput 	= buttons.p2LeftInput;
            rightInput 	= buttons.p2RightInput;
            upInput 	= buttons.p2UpInput;
            downInput 	= buttons.p2DownInput;
            jumpInput 	= buttons.p2JumpInput;
            attackInput = buttons.p2AttackInput;
            defendInput  = buttons.p2DefendInput; 
            specialInput = buttons.p2SpecialInput;
            techInput 	= buttons.p2TechInput;
            pauseInput  = buttons.p2PauseInput;
        }

    }
    
}