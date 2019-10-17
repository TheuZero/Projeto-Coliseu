using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IHpListener
{
    void OnHpChange(float hp, float maxHp);
}
