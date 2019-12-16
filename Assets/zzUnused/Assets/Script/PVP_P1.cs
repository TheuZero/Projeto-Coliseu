using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PVP_P1 : MonoBehaviour
{

    Menu menuRef;

    
    public GameObject can_ini;
    public GameObject can_pvp;


    public Button btn_p1;
    
    public string p1_Atack;
    public string p1_AtackEs;

    public string p1_left;
    public string p1_right;
    private int local = 0;
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
     Can(p1_Atack,p1_AtackEs);
     Tecla(p1_left,p1_right);
    }


    public void Lugar(int local)
    {
             
            if(local == 0)
            {
                btn_p1.transform.localPosition = new Vector3(-280,0,0);
            }
            if(local == 1)
            {
                btn_p1.transform.localPosition = new Vector3(-132,0,0);
            }
            if(local == 2)
            {
                btn_p1.transform.localPosition = new Vector3(23,0,0);
            }
            if(local == 3)
            {
                btn_p1.transform.localPosition = new Vector3(166,0,0);
            }
            if(local == 4)
            {
                btn_p1.transform.localPosition = new Vector3(291,0,0);
            }
            
    }

    public void Tecla(string p1_left,string p1_right)
    {   if(selecionou == false)
        {
            if(Input.GetKeyDown(p1_left))
            {
                if(local > 0)
                {
                    local --;
                }else
                {
                    local = 0;
                }
            }
            else if(Input.GetKeyDown(p1_right))
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
    public void Can(string p1_Atack,string p1_AtackEs)
    {
        Lugar(local);
        if(selecionou == false){
            if(Input.GetKeyDown(p1_AtackEs))
            {
                    menuRef.can_ini.SetActive(true);
                    menuRef.can_pvp.SetActive(false);            
            }
            if(Input.GetKeyDown(p1_Atack))
            {
                selecionou = true;
            }
        }
        if(selecionou == true)
        {
        if(Input.GetKeyDown(p1_AtackEs))
            {
                selecionou = false;
                return;           
            }
        }
    }

}
