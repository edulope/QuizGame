using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using System;

public class UserService : MonoBehaviour
{
    private string dbName = "URI=file:QuizGame.db";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public bool UsernameExists(string username, string password){
        var connection = new SqliteConnection(dbName);
        connection.Open();

        var command = connection.CreateCommand();
        IDbCommand dbCommandReadValues = connection.CreateCommand();
        dbCommandReadValues.CommandText =string.Format("select count(*) from USER u where u.username = \"{0}\" AND u.password = \"{1}\";", username, password);
        int result = Convert.ToInt32(dbCommandReadValues.ExecuteScalar());
        
        connection.Close();

        return result != 0;
    }
}
