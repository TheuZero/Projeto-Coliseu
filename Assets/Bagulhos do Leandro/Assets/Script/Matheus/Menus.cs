using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    MenuReferences menuReferences;
    public GameObject[] acessibleMenus;
    public Button[] actualButtons;
    float actualIndex;
    void OnEnable()
    {
        menuReferences = transform.parent.GetComponent<MenuReferences>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
