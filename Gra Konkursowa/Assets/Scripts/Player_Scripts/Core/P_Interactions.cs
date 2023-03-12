using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class P_Interactions : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField]
    TextMeshProUGUI interactionText;
    bool inRange;
    [SerializeField]
    Animator animationController;
    [SerializeField]
    string baseString = "Press F to ";
    bool textShowed;
    IInteractable objectInteracting;
    [SerializeField]
    Transform interactionPoint;


    void Start() => G_Controller.instatnce.inputs.Other_Map.Interaction.performed += _ => Interaction();

    private void Update()
    {
        baseString = "Press " + G_Controller.instatnce.inputs.asset["Interaction"].GetBindingDisplayString().ToUpper() + " to ";
        if (Physics.Raycast(interactionPoint.position, interactionPoint.forward, out RaycastHit hit, 2.5f))
        {
            objectInteracting = hit.collider.gameObject.GetComponent<IInteractable>();

            if (objectInteracting != null)
            {
                inRange = true;
                interactionText.text = baseString + objectInteracting.InteractionText;
                if (!textShowed) ShowText(true);
            }
            else
            {
                inRange = false;
                if (textShowed) ShowText(false);
            }
        }
        else
        {
            inRange = false;
            if (textShowed) ShowText(false);
        }
    }

    void Interaction()
    {
        if (inRange)
        {
            G_Controller.instatnce.lastInteraction = objectInteracting;
            objectInteracting.Interaction();
        }
    }

    public void InteractingWith(string thing) => interactionText.text += thing;

    void ShowText(bool state)
    {
        if (state) animationController.SetBool("Show_Interaction_Text", true);
        else animationController.SetBool("Show_Interaction_Text", false);
        textShowed = state;
    }
}