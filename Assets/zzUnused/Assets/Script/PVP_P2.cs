using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PVP_P2 : MonoBehaviour
{
    Menu menuRef;

    public GameObject can_ini;
    public GameObject can_pvp;


    public Button btn_p2;
    
    public string p2_Atack;
    public string p2_AtackEs;

    public string p2_left;
    public string p2_right;
    private int local = 4;
    private Boolean selecionou;

    // Start is called before the first frame update
    void Start()
    {
        menuRef = transform.parent.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<Menu>();
        selecionou = false;
    }

    // Update is called once per frame
    void Update()
    {
     Lugar(local);   
     Can(p2_Atack,p2_AtackEs);
     Tecla(p2_left,p2_right);
    }

    
    public void Lugar(int local)
    {
             
            if(local == 0)
            {
                btn_p2.transform.localPosition = new Vector3(-280,0,0);
            }
            if(local == 1)
            {
                btn_p2.transform.localPosition = new Vector3(-132,0,0);
            }
            if(local == 2)
            {
                btn_p2.transform.localPosition = new Vector3(23,0,0);
            }
            if(local == 3)
            {
                btn_p2.transform.localPosition = new Vector3(166,0,0);
            }
            if(local == 4)
            {
                btn_p2.transform.localPosition = new Vector3(291,0,0);
            }
            
    }

    public void Tecla(string p2_left,string p2_right)
    {   if(selecionou == false)
        {
            if(Input.GetKeyDown(p2_left))
            {
                if(local > 0)
                {
                    local --;
                }else
                {
                    local = 0;
                }
            }
            else if(Input.GetKeyDown(p2_right))
            {
                if(local < 4)
                {
                    local++;
                }else
                {
                    local = 4;
                }
            }
        }
    }
    public void Can(string p2_Atack,string p2_AtackEs)
    {
        Lugar(local);
        if(selecionou == false){
            if(Input.GetKeyDown(p2_AtackEs))
            {
                    menuRef.can_ini.SetActive(true);
                    menuRef.can_pvp.SetActive(false);            
            }
            if(Input.GetKeyDown(p2_Atack))
            {
                selecionou = true;
            }
        }
        if(selecionou == true)
        {
        if(Input.GetKeyDown(p2_AtackEs))
            {
                selecionou = false;
                return;           
            }
        }
    }
}
