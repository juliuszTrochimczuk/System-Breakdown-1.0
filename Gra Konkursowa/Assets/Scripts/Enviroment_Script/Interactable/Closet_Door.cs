using UnityEngine;

public class Closet_Door : MonoBehaviour, IInteractable
{
    [Header("Animator")]
    [SerializeField]
    Animator animator;

    [Header("Cost")]
    [SerializeField]
    int cost;
    [SerializeField]
    int indexInSave;

    [Header("Interaction")]
    string interactionText;
    bool canInteract = true;

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

    void Start()
    {
        interactionText = "pay " + cost.ToString() + " scrap to open the door";
        DoorUnlock();

    }

    void DoorPayment()
    {
        if (CanInteract && G_Controller.instatnce.PlayerMoney.Scrap >= cost)
        {
            G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Closet_Door_Unlock");
            G_Controller.instatnce.SaveData.terminalsIndex[indexInSave] = true;
            G_Controller.instatnce.PlayerMoney.Scrap -= cost;
            DoorUnlock();
        }
    }

    void DoorUnlock()
    {
        if (G_Controller.instatnce.SaveData.terminalsIndex[indexInSave])
        {
            animator.SetTrigger("Opening");
            Destroy(this.gameObject.GetComponent<Closet_Door>(), 1);
        }
    }

    public void Interaction() => DoorPayment();
}
