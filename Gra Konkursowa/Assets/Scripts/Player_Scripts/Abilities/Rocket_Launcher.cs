using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Launcher : Ability
{
    [Header("Rocket prefab")]
    [SerializeField]
    GameObject rocket;

    [Header("Active rocket")]
    GameObject activeMissle;
    P_Rocket rocketParametrs;

    [Header("Tiers changes")]
    [SerializeField]
    List<int> damage;
    [SerializeField]
    List<float> rangeOfExplosion;

    void SendingRocket()
    {
        activeMissle = Instantiate(rocket, gameObject.transform.position, Quaternion.identity);

        rocketParametrs = activeMissle.GetComponent<P_Rocket>();
        rocketParametrs.damage = damage[activeTier];
        rocketParametrs.radius = rangeOfExplosion[activeTier];

        activeMissle.transform.rotation = Quaternion.Euler(0.0f, G_Controller.instatnce.player.GetChild(0).transform.rotation.eulerAngles.y, 0.0f);

        G_Controller.instatnce.PlayerSkills.RefreshingCooldown(abilityIndex);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Rocket_Launcher");
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (CheckingToActive(gameObject))
            SendingRocket();
        else if (rocketParametrs != null && !rocketParametrs.exploded && activeTier == 2)
            rocketParametrs.Explosion(activeMissle.transform.position);
    }

}
