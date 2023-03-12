using UnityEngine;

public class Hub_Enter : MonoBehaviour
{
    bool entered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !entered)
        {
            entered = true;

            G_Controller.instatnce.UIController.PreparingForLoading("Hub");
            G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Tutorial_Music", false);

            G_Controller.instatnce.SaveData.tutorialDone = true;
        }
    }
}
