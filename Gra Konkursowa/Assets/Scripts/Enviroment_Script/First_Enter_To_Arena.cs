using System.Collections;
using UnityEngine;

public class First_Enter_To_Arena : MonoBehaviour
{
    void Start()
    {
        G_Controller.instatnce.UIController.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WaitForShow());
    }

    IEnumerator WaitForShow()
    {
        yield return new WaitForSeconds(1.0f);

        G_Controller.instatnce.UIController.difficultyText.text = G_Controller.instatnce.difficulty.ToString();
        G_Controller.instatnce.UIController.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Hub_Music", false);
    }
}
