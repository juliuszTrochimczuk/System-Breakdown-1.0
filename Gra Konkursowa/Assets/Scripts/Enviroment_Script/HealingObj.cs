using UnityEngine;

public class HealingObj : MonoBehaviour
{
    public bool isAMedkit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isAMedkit) G_Controller.instatnce.PlayerHealth.ChangeHP(P_Health.HPchangingActions.MedkitPickUp);
            //else G_Controller.instatnce.PlayerHealth.ChangeHP(Health.HPchangingActions.SyriengeHealing);
            else G_Controller.instatnce.PlayerHealth.ChangeHP(P_Health.HPchangingActions.SyriengeHealing);
            Destroy(this.gameObject);
        }
    }
}
