using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class ReloadText_Controller : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Reload_Text;
    void Update()
    {
        Reload_Text.text = "Press " + G_Controller.instatnce.inputs.asset["Reload_Weapon"].GetBindingDisplayString().ToUpper() + " to reload";
    }
}
