using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField]
    QuestionService questionService;

    List<QuestionDTO> questions;

    bool gameStarted;

    bool cooldownStarted;

    float timer;

    public float maxTimer;

    float CoolDownTimer;

    public float maxCoolDownTimer;

    GameObject currentAnswer;

    [SerializeField]
    private TextMeshProUGUI title;

    [SerializeField]
    private List<GameObject> alts;

    [SerializeField]
    private GameObject timerComponent;

    [SerializeField]
    private TextMeshProUGUI scoreComponent;

    [SerializeField]
    private ScoreService scoreService;

    private Animator timerAnimator;

    private Color defaultColor = new Color32(110, 150, 236, 255);

    private Color failColor = new Color32(231, 67, 85, 255);

    private Color correctColor = new Color32(110, 236, 146, 255);

    private int score;

    private bool inputWasGiven;

    [SerializeField]
    private SessionService sessionService;

    // Start is called before the first frame update
    void Start()
    {
        questions = questionService.get3Questions();
        gameStarted = false;
        timer = 0;
        CoolDownTimer = 0;
        score = 0;
        timerAnimator = timerComponent.GetComponent<Animator>();
        inputWasGiven = false;
        TextMeshProUGUI scoreComponentText = scoreComponent.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        scoreComponentText.text = string.Format("{0}", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(CoolDownTimer <= 0){
            if(gameStarted){
                timer -= Time.deltaTime;
                if(timer<=0){
                    gameStarted = false;
                    timerAnimator.SetBool("gameStarted", gameStarted);
                    CoolDownTimer = maxCoolDownTimer;
                    if(!inputWasGiven){
                        paintCorrectAnswerRed();
                    }
                }
            }
            else{
                roundInitializer();
            }
        }
        else {
             CoolDownTimer -= Time.deltaTime;
        }
        
    }

    private void roundInitializer(){
        if(questions.Count < 1){
            finishGame();
            return;
        }

        resetAltColors();

        List<int> indexes = new List<int> {1, 2, 3, 4};
        QuestionDTO currentQuestion = questions[0];
        questions.RemoveAt(0);

        TextMeshProUGUI questionTitle = title.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        questionTitle.text = currentQuestion.Question;

        foreach (var alt in alts) {
            GameObject altChildComponent = alt.transform.GetChild(0).gameObject;
            TextMeshProUGUI altText = altChildComponent.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
            int popIndex = UnityEngine.Random.Range(0, indexes.Count);
            int index = indexes[popIndex];
            indexes.RemoveAt(popIndex);
            if(index == 1){
                currentAnswer = alt;
                altText.text = currentQuestion.Alt1;
            }
            else if(index == 2){
                altText.text = currentQuestion.Alt2;
            }
            else if(index == 3){
                altText.text = currentQuestion.Alt3;
            }
            else if(index == 4){
                altText.text = currentQuestion.Alt4;
            }
        }

        timer = maxTimer;
        gameStarted = true;
        timerAnimator.SetBool("gameStarted", gameStarted);
        inputWasGiven = false;
    }

    public void altSelected(GameObject alt){
        //print("Here");
        print(inputWasGiven);
        print(CoolDownTimer);
        print(gameStarted);
        if(!inputWasGiven && CoolDownTimer <= 0 && gameStarted){
            //print("Entered");
            inputWasGiven = true;
            Image answerImage = currentAnswer.GetComponent<Image>();
            answerImage.color = correctColor;
            if(alt == currentAnswer){
                //print("Entered if");
                score += 1;
                TextMeshProUGUI scoreComponentText = scoreComponent.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
                scoreComponentText.text = string.Format("{0}", score);
            }
            else{
                //print("Entered else");
                Image inputImage = alt.GetComponent<Image>();
                inputImage.color = failColor;
            }
        }
    }

    void finishGame(){
        print("saving");
        saveScore();
        SceneManager.LoadScene(4);
    }

    void paintCorrectAnswerRed(){
        Image answerImage = currentAnswer.GetComponent<Image>();
        answerImage.color = failColor;
    }

    void resetAltColors(){
         foreach (var alt in alts) {
            Image answerImage = alt.GetComponent<Image>();
            answerImage.color = defaultColor;
         }
    }

    void saveScore(){
        string username = sessionService.getUsername();
        scoreService.addScore(username, score);
        PlayerPrefs.SetInt("score", score);
    }

}
