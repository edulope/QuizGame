using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;
using System;


public class QuestionService : MonoBehaviour
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

    public List<QuestionDTO> get3Questions(){
        var connection = new SqliteConnection(dbName);
        connection.Open();

        var command = connection.CreateCommand();
        IDbCommand dbCommandReadValues = connection.CreateCommand();
        dbCommandReadValues.CommandText = "select * from QUESTION";
        IDataReader reader = dbCommandReadValues.ExecuteReader();

        List<QuestionDTO> data = new List<QuestionDTO>();
        List<QuestionDTO> returningQuestions = new List<QuestionDTO>();



        while(reader.Read()){
            QuestionDTO questionDTO = new QuestionDTO();
            questionDTO.Question = (string) reader["question"];
            questionDTO.Alt1 = (string) reader["alt1"];
            questionDTO.Alt2 = (string) reader["alt2"];
            questionDTO.Alt3 = (string) reader["alt3"];
            questionDTO.Alt4 = (string) reader["alt4"];
            data.Add(questionDTO);
        }

        connection.Close();

        for (int i = 0; i < 3; i++){
            int popIndex = UnityEngine.Random.Range(0, data.Count);
            returningQuestions.Add(data[popIndex]);
            data.RemoveAt(popIndex);
        }
        
        return returningQuestions;
    }
}
