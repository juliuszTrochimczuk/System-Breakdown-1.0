using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Graphics_Settings : MonoBehaviour
{
    Resolution[] resolutions;

    [Header("Resolution components")]
    [SerializeField]
    TMP_Dropdown resolutionDropdown;
    [SerializeField]
    Toggle isFullscreen;

    [Header("Quality components")]
    [SerializeField]
    TMP_Dropdown qualityDropdown;
    List<string> qualityLevels = new List<string> { "Low", "Medium", "High", "Ultra" };

    void OnEnable()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> options = new List<string>();
        List<Resolution> resolutionsList = new List<Resolution>();

        int LastWidth = 0;
        int LastHeight = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].width != LastWidth && resolutions[i].height != LastHeight)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                resolutionsList.Add(resolutions[i]);
                if (resolutions[i].width == PlayerPrefs.GetInt("ScreenWidth", 1920) && resolutions[i].height == PlayerPrefs.GetInt("ScreenHeight", 1080))
                    currentResolutionIndex = options.Count - 1;
                LastWidth = resolutions[i].width;
                LastHeight = resolutions[i].height;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutions = resolutionsList.ToArray();
        SetResolution(currentResolutionIndex);
        isFullscreen.isOn = Screen.fullScreen;

        for (int i = 0; i < qualityLevels.Count; i++)
        {
            if (i == PlayerPrefs.GetInt("GraphicsQuality"))
            {
                qualityDropdown.value = i;
                qualityDropdown.RefreshShownValue();
                break;
            }
        }
    }

    public void SetQualityLevel(int qualityIndex)
    {
        PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        if (isFullscreen) PlayerPrefs.SetInt("isFullscreen", 1);
        else PlayerPrefs.SetInt("isFullscreen", 0);

        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        PlayerPrefs.SetInt("ScreenWidth", resolution.width);
        PlayerPrefs.SetInt("ScreenHeight", resolution.height);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
