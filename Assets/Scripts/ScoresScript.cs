using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoresScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoresComponent;

    [SerializeField]
    ScoreService scoreService;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI scoresComponentText = scoresComponent.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        scoresComponentText.text = getScoresText();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    string getScoresText(){
        List<ScoreDTO> scores = scoreService.getTop10Scores();
        string returningString = "";
        for(int i = 0; i<scores.Count; i++){
            ScoreDTO score = scores[i];
            if(i != 0){
                returningString += "\n";
            }
            returningString += score.toFormatString();
        }
        return returningString;
    }
}
