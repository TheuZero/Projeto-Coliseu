using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string s;
    public GameObject tes;
    public GameObject can_his;
    public GameObject can_ini;
    public GameObject can_pvp;
    public GameObject can_record;
    public GameObject can_op;
    public GameObject can_controle;
    public GameObject can_Audio;
    public GameObject can_Video;
    
    public string p1_Atack;
    public string p1_AtackEs;
    public string p1_down;
    public string p1_up;
    public string p1_left;
    public string p1_right;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Sair(s);
    }

    public void Sair(string s)
    {
        if(Input.GetKeyDown(s))
        {
            Application.Quit();
        }
    }
}