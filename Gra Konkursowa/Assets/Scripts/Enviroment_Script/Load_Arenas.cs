using UnityEngine;

public class Load_Arenas : MonoBehaviour
{
    bool entered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !entered)
        {
            entered = true;
            G_Controller.instatnce.UIController.PreparingForLoading();
        }
    }
}
