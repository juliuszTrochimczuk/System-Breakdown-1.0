using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading_Scene : StateMachineBehaviour
{
    [Header("Which scene to load")]
    [SerializeField]
    string scene;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch (scene)
        {
            case "Hub":
                G_Controller.instatnce.UIController.PreparingForLoading("Hub");
                break;
            case "Arena":
                G_Controller.instatnce.UIController.PreparingForLoading();
                break;
        }
    }
}
