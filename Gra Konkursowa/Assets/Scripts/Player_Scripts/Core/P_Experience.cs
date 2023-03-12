using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System.Collections;

public class P_Experience : MonoBehaviour
{
    public UnityEvent levelUpActions;

    public float XP
    {
        get
        {
            return experiencePoints;
        }
        set
        {
            experiencePoints = value;

            if (experiencePoints > experienceBarier)
            {
                if (level >= 10)
                {
                    level = 10;
                    levelText.text = "level Max";
                    xpBar.value = 1;
                }
                else
                {
                    experiencePoints -= experienceBarier;

                    level++;
                    G_Controller.instatnce.SaveData.level = level;
                    levelText.text = "level " + level.ToString();

                    SkillPoints++;
                    G_Controller.instatnce.SaveData.skillPoints = SkillPoints;

                    levelUpActions.Invoke();
                }
            }

            G_Controller.instatnce.SaveData.experiencePoint = experiencePoints;
        }
    }
    float experiencePoints;
    float experienceBarier = 250.0f;

    [Header("Level")]
    public int level = 1;
    [SerializeField]
    TextMeshProUGUI levelText;
    [SerializeField]
    GameObject levelUpText;

    [Header("Full skill point")]
    [SerializeField]
    int skillPoint;
    public int SkillPoints
    {
        get { return skillPoint; }
        set
        {
            skillPoint = value;
            G_Controller.instatnce.SaveData.skillPoints = skillPoint;

            G_Controller.instatnce.UIController.skillPointsWallet.text = skillPoint.ToString();

            if (skillPoint < 0)
                skillPoint = 0;
        }
    }

    [Header("XP Bar")]
    public float xpBarSpeed;
    public Slider xpBar;

    private void Start()
    {
        XP = G_Controller.instatnce.SaveData.xP;
        level = G_Controller.instatnce.SaveData.level;
        levelText.text = "level " + level.ToString();
        SkillPoints = G_Controller.instatnce.SaveData.skillPoints;

        if (level > 1) experienceBarier += (150.0f * level);
    }

    void Update()
    {
        if (XP / experienceBarier - 0.01f > xpBar.value) //XP wzros³o
        {
            float delta = xpBarSpeed * Time.deltaTime; //oblicz zmianê
            if (delta + xpBar.value > XP / experienceBarier) xpBar.value = XP / experienceBarier; //jeœli zmiana jest wiêksza ni¿ zosta³a paska do dodania ustaw pasek na XP od 0 do 1
            else xpBar.value += delta;
        }
        else if (XP / experienceBarier + 0.01f < xpBar.value) //XP zmala³o
        {
            float delta = xpBarSpeed * Time.deltaTime; //oblicz zmianê
            if (xpBar.value - delta < XP / experienceBarier) xpBar.value = XP / experienceBarier; //jeœli zmiana jest wiêksza ni¿ zosta³a paska do odjêcia ustaw pasek na XP od 0 do 1
            else xpBar.value -= delta;
        }
    }

    public void ResetingProgress()
    {
        levelText.text = "level " + level.ToString();
        experienceBarier = 200.0f;
    }

    public void IncreaseExperienceBarrier()
    {
        experienceBarier += 250.0f;
    }

    public void ResetingResources()
    {
        G_Controller.instatnce.PlayerHealth.HP = G_Controller.instatnce.PlayerHealth.maxHP;
        G_Controller.instatnce.PlayerShooting.AmmoChanging(G_Controller.instatnce.PlayerPassive.maxAmmoValue[G_Controller.instatnce.PlayerPassive.listOfTiers[2]]);
    }

    public void VisualLevelUp()
    {
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Level_Up");

        StartCoroutine(textAnimation());
    }

    private IEnumerator textAnimation()
    {
        levelUpText.SetActive(true);

        yield return new WaitForSeconds(1.05f);

        levelUpText.SetActive(false);
    }
}
