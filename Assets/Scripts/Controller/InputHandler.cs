using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//InputHandler ou ActionHandler seria um bom nome?
public class InputHandler : MonoBehaviour
{
    AttackController attackFreeze;
    RikiAttackController attackRiki;
    CauboiAttackController attackCauboi;
    CronosAttackController attackCronos;


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
    public OffensiveInputValidation TechDown;
    public OffensiveInputValidation TechHold;
    public OffensiveInputValidation TechUp;
    public InputValidation MoveLeftDown;
    public InputValidation MoveLeftHold;
    public InputValidation MoveLeftUp;
    public InputValidation MoveRightDown;
    public InputValidation MoveRightHold;
    public InputValidation MoveRightUp;
    public InputValidation JumpDown;
    public InputValidation JumpHold;
    public InputValidation JumpUp;
    string charName;
    

    bool confirm;

    void Start()
    {
        charName = gameObject.name;
        anim = GetComponent<Animator>();
        animTimers = new BasicAnimTimers();
        
        movement = GetComponent<MovementController>();
        AddCommands();
        getAnimTimers();
    }

    void OnEnable(){
        AddCommands();
    }
    void OnDisable(){

    }

    void AddCommands(){
        switch(charName){
            case "Freeze":
                attackFreeze = GetComponent<AttackController>();
                AttackDown += attackFreeze.ComboVerify;
                TechDown += attackFreeze.IceBallVerify;
                SpecialDown += attackFreeze.IcePillarVerify;
                break;
            case "Riki":
                attackRiki = GetComponent<RikiAttackController>();
                AttackDown += attackRiki.ComboVerify;
                TechDown += attackRiki.TechVerify;
                SpecialDown += attackRiki.SuperBeatVerify;
                break;
            case "Cauboi":
                attackCauboi = GetComponent<CauboiAttackController>();
                AttackDown += attackCauboi.ComboVerify;
                TechDown += attackCauboi.TechVerify;
                SpecialDown += attackCauboi.SuperBeatVerify;
                Debug.Log("cauboi");
                break;
            case "Dr Cronos":
                attackCronos = GetComponent<CronosAttackController>();
                AttackDown += attackCronos.ComboVerify;
                TechDown += attackCronos.TechVerify;
                SpecialDown += attackCronos.SuperBeatVerify;
                break;

        }
        MoveRightDown = movement.TapRight;
        MoveRightHold = movement.WalkRight;
        MoveRightUp = movement.CancelWalk;
        MoveLeftDown = movement.TapLeft;
        MoveLeftHold = movement.WalkLeft;
        MoveLeftUp = movement.CancelWalk;
        JumpDown += movement.JumpVerify;
        JumpHold += movement.ContinuousJump;
        JumpUp += movement.JumpEnd;

    }
    void RemoveCommands(){
        switch(charName){
            case "Freeze":
                AttackDown -= attackFreeze.ComboVerify;
                SpecialDown -= attackFreeze.IcePillarVerify;
                TechDown -= attackFreeze.IceBallVerify;
                break;
            case "Riki":
                AttackDown -= attackRiki.ComboVerify;
                break;
        }
        JumpDown -= movement.JumpVerify;
        //JumpHold -= movement.JumpHold();
        JumpUp -= movement.JumpEnd;
        
    }

    public bool WasExecuted(int command, int type){
        confirm = true;
        if(command == InputValues.moveXpos){
            if(type == InputType.down){
                return confirm = MoveRightDown();
                return true;
            }else if(type == InputType.hold){
                return confirm = MoveRightHold();
            }else if(type == InputType.up){
                return confirm = MoveRightUp();
            }
        }if(command == InputValues.moveXneg){
            if(type == InputType.down){
                return confirm = MoveLeftDown();
                return true;
            }else if(type == InputType.hold){
                return confirm = MoveLeftHold();
            }else if(type == InputType.up){
                return confirm = MoveLeftUp();
            }
        }
        if(command == InputValues.jump){
            if(type == InputType.down){
                confirm = JumpDown();
            }else if(type == InputType.hold){
                
                confirm = JumpHold();
            }else if(type == InputType.up){
                confirm = JumpUp();
            }

        }
        if(command == InputValues.attack){
            Debug.Log("atacouu");
            if(type == InputType.down){
                confirm = AttackDown();
            }else if(type == InputType.hold){
                //confirm = AttackHold();
                confirm = true;
            }else if(type == InputType.up){
                //confirm = AttackUp();
                confirm = true;
            }
        }
        if(command == InputValues.moveY){
            if(type == InputType.down){
                confirm = true;
            }else if(type == InputType.hold){
                confirm = true;
            }else if(type == InputType.up){
                confirm = true;
            }
        }
        if(command == InputValues.nSpecial){
            if(type == InputType.down){
                confirm = SpecialDown();
            }else if(type == InputType.hold){
                //confirm = SpecialHold();
                confirm = true;
            }else if(type == InputType.up){
                //confirm = SpecialUp();
                confirm = true;
            }
        }
        if(command == InputValues.tech){
            if(type == InputType.down){
                confirm = TechDown();
            }else if(type == InputType.hold){
                //confirm = TechHold();
                confirm = true;
            }else if(type == InputType.up){
                //confirm = TechUp();
                confirm = true;
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
