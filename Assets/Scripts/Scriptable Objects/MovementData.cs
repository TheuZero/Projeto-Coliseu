using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillMoveData", menuName = "Skill Move Data", order = 54)]
public class MovementData : ScriptableObject
{
    [SerializeField]
    public MovementationData[] moveData = new MovementationData[0];
}

public class MovementationData{      
    enum DirectionX{
        nothing = 0,
        front = 1,
        back = -1
    }
    enum DirectionY{
        nothing = 0,
        up = 1,
        down = -1
    }
    float xSpeed;
    float ySpeed;
    DirectionX xOrientation;
    DirectionY yOrientation;
}