using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Digital_Code_Lock_Controller : MonoBehaviour, IInteractable
{
    bool canInteract = true;

    [SerializeField] string interactionText;
    [SerializeField] private GameObject digital_code_screen;
    [SerializeField] private string codeSequence;
    [SerializeField] private string correctSequence;
    [SerializeField] TextMeshProUGUI code;
    [SerializeField] GameObject cinematic;
    public bool ShouldBeActive { get; private set; }
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

    public string InteractionText
    {
        get
        {
            return interactionText;
        }
    }

    public void OpenTerminal()
    {
        if (CanInteract)
        {
            if (G_Controller.instatnce.gameStateManager.CurrentState is InTheHub) ShouldBeActive = true;
            digital_code_screen.SetActive(true);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, false);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, false);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, false);

        }
    }
    public void ExitTerminal()
    {
        if (G_Controller.instatnce.gameStateManager.CurrentState is InTheHub) ShouldBeActive = false;
        digital_code_screen.SetActive(false);

        if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.onTheArenaState)
        {
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, true);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, true);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, true);
        }
        else if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.inTheHubState)
        {
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, true);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, true);
        }
    }
    public void GetNumber(int number)
    {
        if (codeSequence.Length < 4)
        {
            codeSequence += number.ToString();
            DisplayCode();

        }
    }

    public void DisplayCode() => code.text = codeSequence;

    public void ClearCode()
    {
        code.text = "0000";
        codeSequence = "";
    }

    public void CodeConfirm()
    {
        if (codeSequence == correctSequence)
        {
            cinematic.SetActive(true);
            digital_code_screen.SetActive(false);
        }
        else
        {
            codeSequence = "#404";
            DisplayCode();
            Invoke("ClearCode", 0.75f);
        }

    }



    public void Interaction() => OpenTerminal();
}

