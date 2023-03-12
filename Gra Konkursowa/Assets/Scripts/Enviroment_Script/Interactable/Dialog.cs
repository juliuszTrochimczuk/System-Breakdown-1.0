using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour, IInteractable
{
    [Header("Interactavle")]
    [SerializeField]
    string interactionText = "talk";

    [SerializeField] private string dialogString;

    public string InteractionText
    {
        get
        {
            return interactionText;
        }
    }

    bool canInteract;
    public bool CanInteract
    {
        get
        {
            return canInteract;
        }
        set
        {
            canInteract = value;
        }
    }

    void ShowUI()
    {
        G_Controller.instatnce.UIController.dialogUI.gameObject.SetActive(true);
        G_Controller.instatnce.UIController.dialogUI.GetLine(dialogString);
    }

    public void Interaction() => ShowUI();
}
