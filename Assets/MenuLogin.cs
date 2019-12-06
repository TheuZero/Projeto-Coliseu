using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;

public class MenuLogin : MonoBehaviour
{
    DBConnect connection = new DBConnect();
    public TMP_InputField user, password;

    void Start(){
        connection = new DBConnect();
    }    
    public void Login(GameObject go){
        if(connection.LoginUsuario(user.text, password.text)[0].Count > 0){
            GoToMenu(go);
            UserSession.userId = Int32.Parse(connection.LoginUsuario(user.text, password.text)[0].ElementAt(0));
            UserSession.userName = connection.LoginUsuario(user.text, password.text)[0].ElementAt(1);
            Debug.Log("Logado com" + UserSession.userName);
        }
    }

    public void GoToMenu(GameObject menu){
        user.text = "";
        password.text = "";
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
