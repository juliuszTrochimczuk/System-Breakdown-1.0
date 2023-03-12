using System.Collections;
using UnityEngine;
using TMPro;

public class Dialog_UI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI dialogText;
    [SerializeField]
    float textSpeed = 0.02f;

    Coroutine typing;

    private void OnEnable()
    {
        SwitchingInputMaps(false);
    }

    private void OnDisable()
    {
        SwitchingInputMaps(true);
    }

    public void GetLine(string line)
    {
        if (typing != null)
        {
            StopCoroutine(typing);
            dialogText.text = "";
        }
        typing = StartCoroutine(TypeLine(line));
    }

    IEnumerator TypeLine(string line)
    {
        foreach (char c in line.ToCharArray())
        {
            dialogText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void SwitchingInputMaps(bool state)
    {
        if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.onTheArenaState)
        {
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, state);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, state);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, state);
        }
        else if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.inTheHubState)
        {
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, state);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, state);
        }
    }

    public void ExitUI()
    {
        gameObject.SetActive(false);
    }
}
