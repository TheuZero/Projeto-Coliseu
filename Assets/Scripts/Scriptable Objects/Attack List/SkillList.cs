using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillList", menuName = "Skill List", order = 53)]
public class SkillList : ScriptableObject
{
    [SerializeField]
    public AttackData[] normalAttack;
    public AttackData[] skill;
    public AttackData[] specialSkill;
}
