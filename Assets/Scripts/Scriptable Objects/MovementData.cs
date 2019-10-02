using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillMoveData", menuName = "Skill Move Data", order = 54)]
public class MovementData : ScriptableObject
{
    [SerializeField]
    public MovementationData[] moveData = new MovementationData[1];
}

[System.Serializable]
public class MovementationData{      
    public enum DirectionX{
        nothing = 0,
        front = 1,
        back = -1
    }
    public enum DirectionY{
        nothing = 0,
        up = 1,
        down = -1
    }
    [SerializeField]
    float xSpeed;
    [SerializeField]
    float ySpeed;
    [SerializeField]
    DirectionX xOrientation;
    [SerializeField]
    DirectionY yOrientation;

    
    public float XSpeed{
        get{
            return xSpeed;
        }
    }
    public float YSpeed{
        get{
            return ySpeed;
        }
    }
    public DirectionX XOrientation{
        get{
            return XOrientation;
        }
    }
    public DirectionY YOrientation{
        get{
            return yOrientation;
        }
    }
    
}