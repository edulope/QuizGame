using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDTO  {

        public string Username { get; set; }
        public int Score { get; set; }

        public string toString(){
            return string.Format("Username: {0}; Score: {1};", Username, Score);
        }

        public string toFormatString(){
            return string.Format("{0} -> {1}", Username, Score);
        }
    }