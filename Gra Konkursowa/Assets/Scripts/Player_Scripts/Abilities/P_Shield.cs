using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Shield : Ability
{
    [Header("Cooldowns and how long is active")]
    [SerializeField]
    List<float> durationOfAbility;

    [Header("Percent of restored health")]
    [SerializeField]
    List<float> howManyHealthToRestore;

    private void OnEnable()
    {       
        if (CheckingToActive(gameObject))
            ActiveShield();
    }

    void ActiveShield()
    {
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Shield");
        float healthToRestore = (G_Controller.instatnce.PlayerHealth.maxHP * howManyHealthToRestore[activeTier]);
        StartCoroutine(HowLongIsActive(durationOfAbility[activeTier], healthToRestore));
    }

    IEnumerator HowLongIsActive(float howLong, float howManyToRestore)
    {
        int healthEachTic = (int)(howManyToRestore / howLong);
        float howLongIsActive = 0.0f;

        while (howLongIsActive < howLong)
        {
            G_Controller.instatnce.PlayerHealth.HP += healthEachTic;
            yield return new WaitForSeconds(1.0f);
            howLongIsActive += 1.0f;
        }

        gameObject.SetActive(false);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Shield", false);
        G_Controller.instatnce.PlayerSkills.RefreshingCooldown(abilityIndex);
    }

}
