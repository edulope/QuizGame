using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltScript : MonoBehaviour
{
    [SerializeField]
    QuizManager quizManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sendInput(){
        quizManager.altSelected(gameObject);
    }
}
