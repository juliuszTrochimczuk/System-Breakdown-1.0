using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [Header("Variables that need to pass")]
    protected int abilityIndex;
    protected float activeCooldown;
    protected int activeTier;

    [Header("Variables for all abilities")]
    [SerializeField]
    List<float> abilityCooldown;

    public void Initialization(int newTier, int newAbilityIndex, float newCooldown)
    {
        activeTier = newTier;
        abilityIndex = newAbilityIndex;
        activeCooldown = newCooldown;
    }

    public float GetAbilityCooldown(int tier)
    {
        return abilityCooldown[tier];
    }

    protected bool CheckingToActive(GameObject @object)
    {
        if (abilityCooldown[activeTier] <= activeCooldown)
        {
            G_Controller.instatnce.PlayerSkills.readyToUse = false;
            return true;
        }

        else 
        {
            @object.SetActive(false);
            return false;
        }
    }
}
