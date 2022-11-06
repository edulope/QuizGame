using System.IO;
using System;
using UnityEngine;


public class SessionService : MonoBehaviour
{

    private const string loginFile = "loginFile.txt";

    public string getUsername(){
        try{
            string username = File.ReadAllText(loginFile);
            return  Base64Helper.Base64Decode(username);
        }
        catch(Exception e){
            print("it was not possible to retreive username from files");
            print(e);
            return "unknown";
        }
    }


}
