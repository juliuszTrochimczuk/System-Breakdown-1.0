using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [Header("Door animator")]
    [SerializeField]
    Animator doorAnimator;

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

    void DoorOpening()
    {
        if (CanInteract) doorAnimator.SetTrigger("Door_Opening");
    }

    public void Interaction() => DoorOpening();
}
