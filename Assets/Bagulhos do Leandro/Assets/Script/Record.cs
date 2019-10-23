using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Record : MonoBehaviour
{
    Menu menuRef;
    public GameObject can_ini;
    public GameObject can_record;
    public string p1_Atack;
    public string p1_AtackEs;
    // Start is called before the first frame update
    void Start()
    {
        menuRef = transform.parent.transform.parent.transform.parent.gameObject.GetComponent<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        Can(p1_Atack,p1_AtackEs);
    }

    public void Can(string p1_Atack,string p1_AtackEs)
    {
        if(Input.GetKeyDown(p1_Atack))
        {
                menuRef.can_ini.SetActive(true);
                menuRef.can_record.SetActive(false);
        }
        if(Input.GetKeyDown(p1_AtackEs))
        {
                menuRef.can_ini.SetActive(true);
                menuRef.can_record.SetActive(false);
        }
    }

}
