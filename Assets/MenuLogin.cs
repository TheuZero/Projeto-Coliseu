using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuLogin : MonoBehaviour
{
    public TMP_InputField user, password;

    public void Login(){

    }

    public void GoToMenu(GameObject menu){
        user.text = "";
        password.text = "";
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
