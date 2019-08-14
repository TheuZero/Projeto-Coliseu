using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AttackData", menuName = "Attack Data", order = 51)]
public class AttackData : ScriptableObject
{
    [SerializeField]
    Sprite icon;
    [SerializeField]
    string attackName = "";
    [SerializeField]
    public HitData[] hitData = new HitData[1];

    public Sprite Icon{
        get{
            return icon;
        }
    }

    public string AttackName{
        get{
            return attackName;
        }
    }
    public float HitNumber{
        get{
            return hitData.Length;
        }
    }
}

[System.Serializable]
public class HitData{
    [SerializeField]
    int dmgMultiplier;
    [SerializeField]
    float knockback;
    [SerializeField]
    float knockup;
    [SerializeField]
    float hitstun;
    [SerializeField]
    float hitlag;

    
    public int DmgMultiplier{
        set{
            dmgMultiplier = value;
        }
        get{
            return dmgMultiplier;
        }
    }

    public float Knockback{
        get{
            return knockback;
        }
    }

    public float Knockup{
        get{
            return knockup;
        }
    }

    public float Hitstun{
        get{
            return hitstun;
        }
    }

    public float Hitlag{
        get{
            return hitlag;
        }
    }
}
