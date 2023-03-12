using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.InputSystem;

public class Start_Application : MonoBehaviour
{
    [SerializeField] private List<InputActionReference> customActions;

    void Awake()
    {
        bool isFullscreen = false;
        int check = PlayerPrefs.GetInt("isFullscreen", 1);
        if (check == 1)
            isFullscreen = true;
        Screen.SetResolution(PlayerPrefs.GetInt("ScreenWidth", 1920), PlayerPrefs.GetInt("ScreenHeight", 1080), isFullscreen);

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("GraphicsQuality"));

        if (!File.Exists(Application.persistentDataPath + "/" + "save_data.json"))
        {
            File.Create(Application.persistentDataPath + "/" + "save_data.json").Dispose();

            SaveStruct data = new SaveStruct()
            {
                tutorialDone = false,

                bestScore = 0,

                money = 0,

                skillPoints = 0,
                experiencePoint = 0,
                xP = 0,
                level = 1,

                passiveTiers = new List<int> { 0, 0, 0 },

                activeTiers = new List<int> { 0, 0, -1, -1 },
                indexAbility1 = 0,
                indexAbility2 = 1,

                terminalsIndex = new List<bool> { false, false, false, false }
            };

            string json = JsonConvert.SerializeObject(data);

            File.WriteAllText(Application.persistentDataPath + "/" + "save_data.json", json);
        }
    }

    void Start()
    {
        foreach(InputActionReference customAction in customActions)
        {
            LoadBindingOverride(G_Controller.instatnce.inputs.asset[customAction.name].name);
        }



        G_Controller.instatnce.AudioMixer.SetFloat("General", Mathf.Log10(PlayerPrefs.GetFloat("GeneralVolume", 1.0f)) * 20);
        G_Controller.instatnce.AudioMixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SFX", 1.0f)) * 20);
        G_Controller.instatnce.AudioMixer.SetFloat("Music", Mathf.Log10(PlayerPrefs.GetFloat("Music", 1.0f)) * 20);

        string saveData = File.ReadAllText(Application.persistentDataPath + "/" + "save_data.json");

        SaveStruct save = JsonConvert.DeserializeObject<SaveStruct>(saveData);

        G_Controller.instatnce.SaveData.tutorialDone = save.tutorialDone;

        G_Controller.instatnce.SaveData.bestScore = save.bestScore;

        G_Controller.instatnce.SaveData.money = save.money;

        G_Controller.instatnce.SaveData.skillPoints = save.skillPoints;
        G_Controller.instatnce.SaveData.experiencePoint = save.experiencePoint;
        G_Controller.instatnce.SaveData.xP = save.xP;
        G_Controller.instatnce.SaveData.level = save.level;

        G_Controller.instatnce.SaveData.passiveTiers = save.passiveTiers;

        G_Controller.instatnce.SaveData.activeTiers = save.activeTiers;
        G_Controller.instatnce.SaveData.indexAbility1 = save.indexAbility1;
        G_Controller.instatnce.SaveData.indexAbility2 = save.indexAbility2;

        G_Controller.instatnce.SaveData.terminalsIndex = save.terminalsIndex;

        G_Controller.instatnce.UIController.PreparingForLoading("Main_Menu");

        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, false);
    }
    public static void LoadBindingOverride(string actionName)
    {
        InputAction action = G_Controller.instatnce.inputs.asset.FindAction(actionName);

        for (int i = 0; i < action.bindings.Count; i++)
        {
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString(action.actionMap + actionName + i)))
                action.ApplyBindingOverride(i, PlayerPrefs.GetString(action.actionMap + actionName + i));
        }
    }
}
