﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    AttackController attack;
    MovementController movement;
    Animator anim;
    BasicAnimTimers animTimers;

    public delegate bool OffensiveInputValidation();
    public delegate bool InputValidation();
    public OffensiveInputValidation SpecialDown;
    public OffensiveInputValidation SpecialHold;
    public OffensiveInputValidation SpecialUp;
    public OffensiveInputValidation AttackDown;
    public OffensiveInputValidation AttackHold;
    public OffensiveInputValidation AttackUp;
    public InputValidation MoveDown;
    public InputValidation MoveHold;
    public InputValidation MoveUp;
    public InputValidation JumpDown;
    public InputValidation JumpHold;
    public InputValidation JumpUp;

    bool confirm;

    void Start()
    {
        anim = GetComponent<Animator>();
        animTimers = new BasicAnimTimers();
        attack = GetComponent<AttackController>();
        movement = GetComponent<MovementController>();

        getAnimTimers();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void AddCommands(){
        AttackDown += 
    }
    public bool WasExecuted(int command, int type){
        confirm = true;
        if(command == InputValues.moveX){
            if(type == InputType.down){
                confirm = true;
            }else if(type == InputType.hold){
                confirm = true;
            }else if(type == InputType.up){
                confirm = true;
            }
        }
        else if(command == InputValues.jump){
            if(type == InputType.down){
                confirm = JumpDown();
            }else if(type == InputType.hold){
                confirm = JumpHold();
            }else if(type == InputType.up){
                confirm = JumpUp();
            }

        }
        else if(command == InputValues.attack){
            if(type == InputType.down){
                confirm = AttackDown();
            }else if(type == InputType.hold){
                confirm = AttackHold();
            }else if(type == InputType.up){
                confirm = AttackUp();
            }
        }
        else if(command == InputValues.moveY){
            if(type == InputType.down){
                confirm = true;
            }else if(type == InputType.hold){
                confirm = true;
            }else if(type == InputType.up){
                confirm = true;
            }
        }
        else if(command == InputValues.nSpecial){
            if(type == InputType.down){
                confirm = SpecialDown();
            }else if(type == InputType.hold){
                confirm = SpecialHold();
            }else if(type == InputType.up){
                confirm = SpecialUp();
            }
        }
        return confirm;
    }

    void getAnimTimers(){
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            switch(clip.name)
            {
                case "Combo 1":
                    animTimers.c1Time = clip.length;
                    break;
                case "Combo 2":
                    animTimers.c2Time = clip.length;
                    break;
                case "Combo 3":
                    animTimers.c3Time = clip.length;
                    break;
                case "Combo 4":
                    animTimers.c4Time = clip.length;
                    break;
                case "Dash":
                    animTimers.dashTime = clip.length;
                    break;
                case "Ice Pillar":
                    animTimers.icePillar = clip.length;
                    break;
            }
        }
    }
}

public class BasicAnimTimers{

        public float c1Time;
        public float c2Time;
        public float c3Time;
        public float c4Time;
        public float dashTime;
        public float icePillar;
}
