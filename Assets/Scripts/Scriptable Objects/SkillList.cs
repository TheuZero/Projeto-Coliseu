using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillList", menuName = "Skill List", order = 53)]
public class SkillList : ScriptableObject
{
    [SerializeField]
    public ScriptableObject[] normalAttack;
}
