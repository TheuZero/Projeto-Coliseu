using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Historia : MonoBehaviour
{
    Menu menuRef;
    public GameObject tes;
    public GameObject can_ini;
    public GameObject can_his;


    public Button btn;
    
    public string p1_Atack;
    public string p1_AtackEs;

    public string p1_left;
    public string p1_right;
    private int local = 0;

    // Start is called before the first frame update
    void Start()
    {
        menuRef = transform.parent.transform.parent.transform.parent.gameObject.GetComponent<Menu>();
               
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
                btn.transform.localPosition = new Vector3(-220,-232,0);
            }
            if(local == 1)
            {
                btn.transform.localPosition = new Vector3(94,-232,0);
            }

            
    }

    public void Tecla(string p1_left,string p1_right)
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
            if(Input.GetKeyDown(p1_right))
            {
                if(local < 1)
                {
                    local++;
                }else
                {
                    local = 1;
                }
            }
    }
    
    public void Can(string p1_Atack,string p1_AtackEs)
    {
        Lugar(local);
        
            if(Input.GetKeyDown(p1_AtackEs))
            {
                menuRef.can_ini.SetActive(true);
                menuRef.can_his.SetActive(false);            
            }
        if(local == 0){    
            if(Input.GetKeyDown(p1_Atack))
            {
                menuRef.tes.SetActive(true);
                menuRef.can_his.SetActive(false);
            }
        
        }
        if(local == 1)
        {
            if(Input.GetKeyDown(p1_Atack))
            {
                menuRef.can_ini.SetActive(true);
                menuRef.can_his.SetActive(false);
            }
        }

    }
    

}
