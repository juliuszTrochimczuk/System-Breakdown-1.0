using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Sound_Settings : MonoBehaviour
{
    [Header("Audio Sliders")]
    [SerializeField]
    Slider masterSlider;
    [SerializeField]
    Slider sfxSlider;
    [SerializeField]
    Slider musicSlider;

    private void OnEnable()
    {
        masterSlider.value = PlayerPrefs.GetFloat("GeneralVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX");
        musicSlider.value = PlayerPrefs.GetFloat("Music");
    }

    public void SetGeneralVolume(float volume)
    {
        PlayerPrefs.SetFloat("GeneralVolume", volume);
        G_Controller.instatnce.AudioMixer.SetFloat("General", Mathf.Log10(volume) * 20);
    }

    public void SetSFXlVolume(float volume)
    {
        PlayerPrefs.SetFloat("SFX", volume);
        G_Controller.instatnce.AudioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("Music", volume);
        G_Controller.instatnce.AudioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }


}