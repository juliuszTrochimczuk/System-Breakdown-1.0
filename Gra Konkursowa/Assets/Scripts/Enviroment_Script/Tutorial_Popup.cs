using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Tutorial_Popup : MonoBehaviour
{
    [Header("Tutorial")]
    [SerializeField]
    TextMeshProUGUI popup;
    [SerializeField]
    string tutorialString;
    [SerializeField]
    Color entryColor;
    [SerializeField]
    Color exitColor;
    [SerializeField]
    float speed;
    private void Start()
    {
        switch(tutorialString)
        {
            case "move":
                tutorialString = "Press W,A,S,D to move around";
                break;
            case "dash":
                tutorialString = "Press " + G_Controller.instatnce.inputs.asset["Dash"].GetBindingDisplayString().ToUpper() + " to dash";
                break;
            case "shoot":
                tutorialString = "Press Left Mouse Button to shoot";
                break;
            case "ability":    
                tutorialString = "Press " + G_Controller.instatnce.inputs.asset["Use_Ability_1"].GetBindingDisplayString().ToUpper() + " to use rocket, " + "press" + G_Controller.instatnce.inputs.asset["Use_Ability_2"].GetBindingDisplayString().ToUpper() + "to use shield";
                break;


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        popup.text = tutorialString;
        popup.CrossFadeColor(entryColor, speed, false, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        popup.text = "";
        popup.CrossFadeColor(exitColor, speed, false, true);
    }
}
