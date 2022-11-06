using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionDTO
    {
        public string Question { get; set; }
        public string Alt1 { get; set; }
        public string Alt2 { get; set; }
        public string Alt3 { get; set; }
        public string Alt4 { get; set; }

        public string toString(){
            return string.Format("Question: {0}; Alt1: {1}; Alt2: {2}; Alt3: {3}; Alt4: {4};", Question, Alt1, Alt2, Alt3, Alt4);
        }
    }
