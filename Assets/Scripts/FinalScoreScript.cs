using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalScoreScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreComponent;

    void Start()
    {
        int score = PlayerPrefs.GetInt("score");
        print(score);

        TextMeshProUGUI scoreComponentText = scoreComponent.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        scoreComponentText.text = string.Format("{0}", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
