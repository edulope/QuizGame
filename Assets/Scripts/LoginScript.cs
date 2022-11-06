using System.Collections;
using System.IO;
using System.Text; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LoginScript : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField Username;

    [SerializeField]
    private TMP_InputField Password;

    [SerializeField]
    private TextMeshProUGUI ErrorMessage;

    [SerializeField]
    private UserService userService;

    private const string loginFile = "loginFile.txt";

    public void ValidateInput(){
        ErrorMessage.text = "";
        bool isValid = true;
        string username = Username.text;
        string password = Password.text;
        if(isValid && username == ""){
            isValid = false;
            ErrorMessage.text = TextConsts.ErrorEmptyUsername;
        }

        if(isValid && password == ""){
            isValid = false;
            ErrorMessage.text = TextConsts.ErrorEmptyPassword;
        }

        if(isValid && !userService.UsernameExists(username, password)){
            isValid = false;
            ErrorMessage.text = TextConsts.ErrorLoginNotFound;
        }

        if(isValid){
            File.WriteAllText(loginFile, Base64Helper.Base64Encode(username));
            SceneManager.LoadScene(1);
        }
    }


}
