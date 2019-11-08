using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Opcoes : MonoBehaviour
{

    Menu menuRef;
    
    public GameObject can_Con;
    public GameObject can_video;
    public GameObject can_Audio;
    public GameObject can_ini;
    

    public Button btn;
    
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
                btn.transform.localPosition = new Vector3(-149,168,0);
            }
            if(local == 1)
            {
                btn.transform.localPosition = new Vector3(-149,64,0);
            }
            if(local == 2)
            {
                btn.transform.localPosition = new Vector3(-149,-42,0);
            }
            if(local == 3)
            {
                btn.transform.localPosition = new Vector3(-149,-150,0);
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
                if(local < 3)
                {
                    local++;
                }else
                {
                    local = 3;
                }
            }
    }
    public void Can(string p1_Atack,string p1_AtackEs)
    {
        Lugar(local);
        if(Input.GetKeyDown(p1_AtackEs))
        {   
            menuRef.can_op.SetActive(false);
            menuRef.can_ini.SetActive(true);
        }
        if(Input.GetKeyDown(p1_Atack))
        {
            if(local == 0)
            {
                menuRef.can_op.SetActive(false);
                menuRef.can_controle.SetActive(true);
            }
            if(local == 1)
            {
                menuRef.can_op.SetActive(false);
                menuRef.can_Audio.SetActive(true);
            }
            if(local == 2)
            {
                menuRef.can_op.SetActive(false);
                menuRef.can_Video.SetActive(true);
            }
            if(local == 3)
            {
                menuRef.can_op.SetActive(false);
                menuRef.can_ini.SetActive(true);
            }

        }
    }


}
