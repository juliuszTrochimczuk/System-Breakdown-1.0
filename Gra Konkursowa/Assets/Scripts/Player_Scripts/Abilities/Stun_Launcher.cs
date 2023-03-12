using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun_Launcher : Ability
{
    [Header("Missle prefab")]
    [SerializeField]
    GameObject missle;

    [Header("Active rocket")]
    GameObject activeMissle;

    [Header("Tiers changes")]
    [SerializeField]
    List<float> timeOfStun;
    
    void SendingRocket()
    {
        activeMissle = Instantiate(missle, gameObject.transform.position, Quaternion.identity);

        Stun stun = activeMissle.GetComponent<Stun>();
        stun.timerOfStun = timeOfStun[activeTier];

        activeMissle.transform.rotation = Quaternion.Euler(0.0f, G_Controller.instatnce.player.GetChild(0).transform.rotation.eulerAngles.y, 0.0f);

        G_Controller.instatnce.PlayerSkills.RefreshingCooldown(abilityIndex);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Rocket_Launcher");
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (CheckingToActive(gameObject))
            SendingRocket();
    }
}
