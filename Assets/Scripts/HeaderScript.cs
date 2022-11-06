using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeaderScript : MonoBehaviour
{
    [SerializeField]
    private SessionService sessionService;

    private TextMeshProUGUI nameField;

    // Start is called before the first frame update
    void Start()
    {
        nameField = gameObject.GetComponent(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        string username = sessionService.getUsername();
        nameField.text = string.Format("Welcome, {0}", username);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
