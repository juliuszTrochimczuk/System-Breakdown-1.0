using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.VFX;
using System.Collections.Generic;

public class P_Health : Health
{
    public new enum HPchangingActions { DamagedByBullet, DamagedByRocket, DamageToPlayer, MedkitPickUp, SyriengeHealing}

    public float FancyHP { get; private set; }
    public Slider bar;

    [Header("Visual Effects")]
    [SerializeField]
    VisualEffect healingEffect;
    [SerializeField]
    ParticleSystem damageEffect;

    void Awake()
    {
        HPanimSpeed = 1;
    }

    void Start()
    {
        HP = maxHP;
        FancyHP = 1;
        if (bar != null)
        {
            bar.minValue = 0;
            bar.maxValue = 1;
            bar.value = 1;
        }
        MainCam = GameObject.Find("Main Camera").transform;
    }

    void Update()
    {
        if ((float)(BitConverter.ToUInt32(BitConverter.GetBytes((float)HP / (float)maxHP), 0) | 0x00ff) > (float)BitConverter.ToUInt32(BitConverter.GetBytes(FancyHP), 0)) //hp wzros³o
        {
            float delta = HPanimSpeed * Time.deltaTime; //oblicz zmianê
            if (delta + FancyHP > HP / maxHP) FancyHP = (float)HP / (float)maxHP; //jeœli zmiana jest wiêksza ni¿ zosta³a paska do dodania ustaw pasek na HP od 0 do 1
            else FancyHP += delta;
        }
        else if ((float)(BitConverter.ToUInt32(BitConverter.GetBytes((float)HP / (float)maxHP), 0) | 0x00ff) < (float)BitConverter.ToUInt32(BitConverter.GetBytes(FancyHP), 0)) //hp zmala³o
        {
            float delta = HPanimSpeed * Time.deltaTime; //oblicz zmianê
            if (FancyHP - delta < HP / maxHP) FancyHP = (float)HP / (float)maxHP; //jeœli zmiana jest wiêksza ni¿ zosta³a paska do odjêcia ustaw pasek na HP od 0 do 1
            else FancyHP -= delta;
        }
        if (bar != null)
        {
            bar.value = FancyHP;
        }
    }

    public void OnPlayerDamaged()
    {
        G_Controller.instatnce.PlayerScore.scoreMultiplier = 1;
        G_Controller.instatnce.PlayerScore.MultiplierBar = 0.0f;

        damageEffect.Play();
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Player_Damage");
    }

    public void OnPlayerDeath()
    {
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Player_Death");

        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, false);

        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Comunistic_Arena_Music", false);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Cyberpunk_Arena_Music", false);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Boss_Arena_Music", false);
    }

    public void ChangeHP(HPchangingActions action)
    {
        switch (action)
        {
            case HPchangingActions.DamagedByBullet:
                HP -= 20;
                break;

            case HPchangingActions.DamagedByRocket:
                HP -= 25;
                break;

            case HPchangingActions.DamageToPlayer:
                HP -= 10;
                break;

            case HPchangingActions.MedkitPickUp:
                G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Player_Healing");
                healingEffect.Play();
                HP = maxHP;
                break;

            case HPchangingActions.SyriengeHealing:
                G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Player_Healing");
                healingEffect.Play();
                HP += 25;
                break;
        }
    }
}
