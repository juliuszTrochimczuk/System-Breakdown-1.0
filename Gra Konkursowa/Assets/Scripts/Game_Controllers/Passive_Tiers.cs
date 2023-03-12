using System.Collections.Generic;
using UnityEngine;

public class Passive_Tiers : MonoBehaviour
{
    [Header("Player health tier")]
    public readonly List<int> maxHealthValue = new List<int> { 100, 125, 150, 175, 200};

    [Header("Player dash cooldown tier")]
    public readonly List<float> dashCooldownValue = new List<float> { 1.5f, 1.2f, 0.75f };

    [Header("Player ammo tier")]
    public readonly List<int> maxAmmoValue = new List<int> { 25, 30, 35, 40, 45 };

    [Header("List of tiers")]
    public List<int> listOfTiers;


    public void SettingPassive()
    {
        listOfTiers[0] = G_Controller.instatnce.SaveData.passiveTiers[0];
        listOfTiers[1] = G_Controller.instatnce.SaveData.passiveTiers[1];
        listOfTiers[2] = G_Controller.instatnce.SaveData.passiveTiers[2];
    }
}
