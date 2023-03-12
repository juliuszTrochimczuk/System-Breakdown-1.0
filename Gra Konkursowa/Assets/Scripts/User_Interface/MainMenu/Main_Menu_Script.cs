using UnityEngine;
using System;
using TMPro;

public class Main_Menu_Script : MonoBehaviour
{
    [Header("Canvas game objects")]
    [SerializeField]
    GameObject openMenu;
    [SerializeField]
    GameObject settingsMenu;
    [SerializeField]
    GameObject graphicsMenu;
    [SerializeField]
    GameObject soundMenu;
    [SerializeField]
    GameObject keyBindMenu;

    [Header("Animator")]
    [SerializeField]
    Animator animator;

    [Header("Big text")]
    [SerializeField]
    TextMeshProUGUI bigText;

    private void Start()
    {
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Main_Menu_Music");
    }

    public void Play()
    {
        openMenu.SetActive(false);
        bigText.gameObject.SetActive(false);

        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Main_Menu_Music", false);

        if (!G_Controller.instatnce.SaveData.tutorialDone) G_Controller.instatnce.UIController.PreparingForLoading("Intro");
        else G_Controller.instatnce.UIController.PreparingForLoading("Hub");
    }

    public void Settings(bool show) => animator.SetBool("Settings", show);
    public void Graphics(bool show) => animator.SetBool("Graphics", show);

    public void Sound(bool show) => animator.SetBool("Sound", show);

    public void Keybind(bool show) => animator.SetBool("Keybind", show);

    public void ChangingBigText(string value) => bigText.text = value;

    public void ButtonSoundEffect() => G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Click_Button");

    public void FollowUs() => Application.OpenURL("https://backbone-studio.itch.io/system-breakdown/rate");

    public void Exit() => Application.Quit();
}