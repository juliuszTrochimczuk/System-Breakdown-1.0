using System.Collections;
using TMPro;
using UnityEngine;

public class TTYinput : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField input;
    private bool selected = false;
    private Coroutine pressed;

    void Start()
    {
        G_Controller.instatnce.inputs.Menu_Map.DownArrow.performed += DownArrow_performed;
        G_Controller.instatnce.inputs.Menu_Map.UpArrow.performed += UpArrow_performed;
        G_Controller.instatnce.inputs.Menu_Map.DownArrow.canceled += DownArrow_canceled;
        G_Controller.instatnce.inputs.Menu_Map.Enter.performed += Enter_performed;
    }

    private void Enter_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(selected) G_Controller.instatnce.UIController.tty.CommandChanged();
    }

    private void DownArrow_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        StopCoroutine(pressed);
    }

    private void UpArrow_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (selected)
        {
            if (G_Controller.instatnce.UIController.tty.ttyHistoryIndex != 0)
            {
                G_Controller.instatnce.UIController.tty.ttyHistoryIndex--;
                input.text = G_Controller.instatnce.UIController.tty.ttyHistory[G_Controller.instatnce.UIController.tty.ttyHistoryIndex];
            }
        }
    }

    private void DownArrow_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (selected)
        {
            pressed = StartCoroutine(ResetTTYindex());
            if (G_Controller.instatnce.UIController.tty.ttyHistoryIndex < G_Controller.instatnce.UIController.tty.ttyHistory.Count)
            {
                G_Controller.instatnce.UIController.tty.ttyHistoryIndex++;
                if (G_Controller.instatnce.UIController.tty.ttyHistoryIndex == G_Controller.instatnce.UIController.tty.ttyHistory.Count)
                {
                    input.text = "";
                }
                else
                {
                    input.text = G_Controller.instatnce.UIController.tty.ttyHistory[G_Controller.instatnce.UIController.tty.ttyHistoryIndex];
                }
            }
        }
    }

    public IEnumerator ResetTTYindex()
    {
        yield return new WaitForSecondsRealtime(2);
        if (G_Controller.instatnce.UIController.tty.ttyHistoryIndex != G_Controller.instatnce.UIController.tty.ttyHistory.Count)
        {
            G_Controller.instatnce.UIController.tty.ttyHistoryIndex = G_Controller.instatnce.UIController.tty.ttyHistory.Count;
            input.text = "";
        }
    }

    public void Selected()
    {
        selected = true;
    }

    public void Deselected()
    {
        selected = false;
    }
}
