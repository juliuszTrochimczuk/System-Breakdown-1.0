using UnityEngine;

public class Pause_UI : MonoBehaviour
{
    private void OnEnable()
    {
        G_Controller.instatnce.UIController.SettingsMenuState(false);
    }

    public void ReturnToHub()
    {
        G_Controller.instatnce.UIController.PreparingForLoading("Hub", false);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Click_Button");
        G_Controller.instatnce.gameStateManager.CurrentState = G_Controller.instatnce.gameStateManager.inTheHubState;
    }

    public void BackToMenu()
    {
        G_Controller.instatnce.gameStateManager.CurrentState = G_Controller.instatnce.gameStateManager.gamePausedState;
        Time.timeScale = 1.0f;
        G_Controller.instatnce.LoadingNewScene("Main_Menu");
        G_Controller.instatnce.AudioPlayer.ResetAllAudio();
        AudioListener.pause = false;
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Click_Button");
        G_Controller.instatnce.UIController.sceneLoaderCanvas.SetActive(true);
    }
}
