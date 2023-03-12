using UnityEngine;

public class Reset_Player_Progress : MonoBehaviour
{
    private void OnEnable()
    {
        G_Controller.instatnce.ResetPlayerProgress();

        gameObject.SetActive(false);
    }
}
