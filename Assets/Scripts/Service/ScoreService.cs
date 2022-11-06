using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;

public class ScoreService : MonoBehaviour
{
     private string dbName = "URI=file:QuizGame.db";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(string username, int score){
        var connection = new SqliteConnection(dbName);
        connection.Open();

        var command = connection.CreateCommand();
        IDbCommand dbCommandReadValues = connection.CreateCommand();
        dbCommandReadValues.CommandText =string.Format( "insert into SCORE(username, score) values('{0}', {1});", username, score);

        dbCommandReadValues.ExecuteNonQuery();
        
        connection.Close();
    }

    public List<ScoreDTO> getTop10Scores(){
        var connection = new SqliteConnection(dbName);
        connection.Open();

        var command = connection.CreateCommand();
        IDbCommand dbCommandReadValues = connection.CreateCommand();
        dbCommandReadValues.CommandText = " SELECT * from score s ORDER by s.score DESC LIMIT 10";
        IDataReader reader = dbCommandReadValues.ExecuteReader();

        List<ScoreDTO> data = new List<ScoreDTO>();

        while(reader.Read()){
            ScoreDTO scoreDTO = new ScoreDTO();
            scoreDTO.Username = (string) reader["username"];
            scoreDTO.Score = Convert.ToInt32(reader["score"]);
            data.Add(scoreDTO);
        }

        connection.Close();

        return data;
    }
}

