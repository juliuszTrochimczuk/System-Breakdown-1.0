using UnityEngine;

public class Opening_Shop : MonoBehaviour, IInteractable
{
    [Header("Shop UI")]
    [SerializeField]
    GameObject shopUI;

    bool canInteract = true;
    [SerializeField]
    string interactionText;

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

    void OpenShop()
    {
        if (CanInteract) shopUI.SetActive(true);
    }

    public void Interaction() => OpenShop();
}
