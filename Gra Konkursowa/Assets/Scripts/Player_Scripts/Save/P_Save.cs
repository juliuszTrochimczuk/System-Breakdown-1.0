using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class P_Save : MonoBehaviour
{
    [Header("Tutorial done")]
    public bool tutorialDone = false;

    [Header("Score")]
    public int bestScore = 0;

    [Header("Money")]
    public int money = 0;

    [Header("Player experience")]
    public int skillPoints = 0;
    public float experiencePoint = 0;
    public float xP = 0;
    public int level = 1;

    [Header("Player Passive")]
    public List<int> passiveTiers = new List<int>() { 0, 0, 0};

    [Header("Player abilities")]
    public List<int> activeTiers = new List<int> { 0, 0, -1, -1};
    public int indexAbility1 = 0;
    public int indexAbility2 = 1;

    [Header("Story Terminals")]
    public List<bool> terminalsIndex = new List<bool> { false, false, false, false };

    private void OnApplicationQuit()
    {
        SaveStruct data = new SaveStruct
        {
            tutorialDone = tutorialDone,

            bestScore = bestScore,

            money = money,

            skillPoints = skillPoints,
            experiencePoint = experiencePoint,
            xP = xP,
            level = level,

            passiveTiers = passiveTiers,

            activeTiers = activeTiers,
            indexAbility1 = indexAbility1,
            indexAbility2 = indexAbility2,

            terminalsIndex = terminalsIndex,
        };

        string json = JsonConvert.SerializeObject(data);

        File.WriteAllText(Application.persistentDataPath + "/" + "save_data.json", json);
    }
}
