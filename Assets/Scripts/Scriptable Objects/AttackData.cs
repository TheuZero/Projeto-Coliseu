using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AttackData", menuName = "Attack Data", order = 51)]
public class AttackData : ScriptableObject
{
    public enum AttackType{
        Normal = 0,
        Skill = 1,
        SpecialSkill = 2
    }
    public enum HitType{
        directAttack = 0,
        projectile = 1,
        solidObject = 2
    }   
    [SerializeField]
    Sprite icon;
    [SerializeField]
    string attackName = "";
    [SerializeField]
    public float cooldown;
    [SerializeField]
    public float manaCost;
    [SerializeField]
    public HitData[] hitData = new HitData[1];
    [SerializeField]
    public AttackType attackType;
    [SerializeField]
    public HitType hitType;
    [SerializeField]
    public MovementData movementData;

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
    public float ManaCost{
        get{
            return manaCost;
        }
    }
}

[System.Serializable]
public class HitData{
    [SerializeField]
    float manaGain;
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

    public float ManaGain{
        get{
            return manaGain;
        }
    }
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
