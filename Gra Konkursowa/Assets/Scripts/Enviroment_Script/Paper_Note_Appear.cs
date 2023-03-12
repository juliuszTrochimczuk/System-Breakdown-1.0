using UnityEngine;

public class Paper_Note_Appear : MonoBehaviour, IInteractable
{
    [Header("Note Content")]
    [SerializeField]
    Sprite content;

    [Header("Interaction")]
    [SerializeField]
    string interactionText;
    bool canInteract;

    public string InteractionText
    {
        get
        {
            return interactionText;
        }
    }

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

    void ShowNote()
    {
        G_Controller.instatnce.UIController.PaperUI.SetActive(true);

        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, false);

        G_Controller.instatnce.UIController.paperText.sprite = content;
    }

    public void Interaction() => ShowNote();
}
