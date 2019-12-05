using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuCadastro : MonoBehaviour
{
    public TMP_InputField user, password, confirmPassword;

    public void Register(){

    }

    bool ConfirmPassword(){
        if(password == confirmPassword){
            return true;
        }
        return false;
    }
    public void GoToMenu(GameObject go){
        user.text = "";
        password.text = "";
        confirmPassword.text = "";
        go.SetActive(true);
        gameObject.SetActive(false);
    }
}
