using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarBehaviour : MonoBehaviour, IHpListener
{
    int hpBarIndex = 0;
    Image hpBar;
    void Start(){
        hpBar = GetComponent<Image>();
    }

    public void OnHpChange(float actualHp, float maxHp, float playerIndex){
        if(hpBarIndex == playerIndex){
            hpBar.fillAmount = actualHp/maxHp;
        }
    }
}
