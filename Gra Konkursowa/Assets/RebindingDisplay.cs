using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;


public class RebindingDisplay : MonoBehaviour
{
    [SerializeField] private InputActionReference customAction = null;

    [SerializeField] private TMP_Text bindingDisplayNameText = null;
    [SerializeField] private GameObject startRebindObject = null;
    [SerializeField] private GameObject waitingForInputObject = null;



    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;
    private void Awake()
    {

    }
    private void Start()
    {
        bindingDisplayNameText.text = G_Controller.instatnce.inputs.asset[customAction.name].GetBindingDisplayString().ToUpper();
    }



    public void StartRebiding()
    {
        var _inputAction = G_Controller.instatnce.inputs.asset[customAction.name];
        startRebindObject.SetActive(false);
        waitingForInputObject.SetActive(true);

        rebindingOperation = _inputAction.PerformInteractiveRebinding()
             .WithControlsExcluding("Mouse")
             .OnMatchWaitForAnother(0.1f)
             .OnComplete(operation => RebindComplete())
             .Start();
    }

    private void RebindComplete()
    {

        var _inputAction = G_Controller.instatnce.inputs.asset[customAction.name];
        bindingDisplayNameText.text = G_Controller.instatnce.inputs.asset[customAction.name].GetBindingDisplayString().ToUpper();
        SaveBindingOverride(_inputAction);
        rebindingOperation.Dispose();
        startRebindObject.SetActive(true);
        waitingForInputObject.SetActive(false);

    }

    private static void SaveBindingOverride(InputAction action)
    {
        for (int i = 0; i < action.bindings.Count; i++)
        {
            PlayerPrefs.SetString(action.actionMap + action.name + i, action.bindings[i].overridePath);
        }
    }




}
