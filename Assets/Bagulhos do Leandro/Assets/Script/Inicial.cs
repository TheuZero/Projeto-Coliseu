using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inicial : MonoBehaviour
{
    Menu menuRef;
    
    public GameObject can_his;
    public GameObject can_ini;
    public GameObject can_pvp;
    public GameObject can_record;
    public GameObject can_op;

    public Button btnInicial;
    
    public string p1_Atack;
    public string p1_AtackEs;
    public string p1_down;
    public string p1_up;
    int local = 0;
    // Start is called before the first frame update
    void Start()
    {
        menuRef = transform.parent.transform.parent.transform.parent.transform.parent.gameObject.GetComponent<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
     Lugar(local);   
     Can(p1_Atack,p1_AtackEs);
     Tecla(p1_up,p1_down);
    }

    public void Lugar(int local)
    {
        
        
            if(local == 0)
            {
                btnInicial.transform.localPosition = new Vector3(-100,198,0);
            }
            if(local == 1)
            {
                btnInicial.transform.localPosition = new Vector3(-100,92,0);
            }
            if(local == 2)
            {
                btnInicial.transform.localPosition = new Vector3(-100,-11,0);
            }
            if(local == 3)
            {
                btnInicial.transform.localPosition = new Vector3(-100,-116,0);
            }
            if(local == 4)
            {
                btnInicial.transform.localPosition = new Vector3(-100,-215,0);
            }
            
    }

    public void Tecla(string p1_up,string p1_down)
    {
            if(Input.GetKeyDown(p1_up))
            {
                if(local > 0)
                {
                    local --;
                }else
                {
                    local = 0;
                }
            }
            else if(Input.GetKeyDown(p1_down))
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
    public void Can(string p1_Atack,string p1_AtackEs)
    {
        Lugar(local);
        if(Input.GetKeyDown(p1_AtackEs))
        {
            Application.Quit();
        }
        if(Input.GetKeyDown(p1_Atack))
        {
            if(local == 0)
            {   
                menuRef.can_ini.SetActive(false);
                menuRef.can_his.SetActive(true);
                local =0;
            }
            if(local == 1)
            {
                menuRef.can_ini.SetActive(false);
                menuRef.can_pvp.SetActive(true);
                local =0;
            }
            if(local == 2)
            {
                menuRef.can_ini.SetActive(false);
                menuRef.can_record.SetActive(true);
                local =0;
            }
            if(local == 3)
            {
                menuRef.can_ini.SetActive(false);
                menuRef.can_op.SetActive(true);
                local =0;
            }
            if(local == 4)
            {
               Application.Quit();
            }
        }
    }
}

