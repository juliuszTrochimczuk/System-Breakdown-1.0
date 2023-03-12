using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P_Skills : MonoBehaviour
{
    [Header("Collection of Abilities")]
    [SerializeField]
    public List<AbilityList> collection;

    [Header("Picked ability")]
    public int indexAbility1;
    public int indexAbility2;

    [Header("Ready to use ability")]
    public bool readyToUse = true;

    [Header("UI representation of ability cooldown")]
    [SerializeField]
    List<Slider> cooldownSliders;
    [SerializeField]
    List<Image> backgroudToSlider;

    void Start()
    {
        G_Controller.instatnce.inputs.Combat_Map.Use_Ability_1.performed += _ => CheckAbility(0);
        G_Controller.instatnce.inputs.Combat_Map.Use_Ability_2.performed += _ => CheckAbility(1);

        indexAbility1 = G_Controller.instatnce.SaveData.indexAbility1;
        indexAbility2 = G_Controller.instatnce.SaveData.indexAbility2;

        collection[0].tier = G_Controller.instatnce.SaveData.activeTiers[0];
        collection[1].tier = G_Controller.instatnce.SaveData.activeTiers[1];
        collection[2].tier = G_Controller.instatnce.SaveData.activeTiers[2];
        collection[3].tier = G_Controller.instatnce.SaveData.activeTiers[3];

        SlotChange();
    }

    public void LoadingAbilities()
    {
        collection[indexAbility1].cooldown += Time.deltaTime;
        cooldownSliders[0].value = collection[indexAbility1].cooldown;
        collection[indexAbility2].cooldown += Time.deltaTime;
        cooldownSliders[1].value = collection[indexAbility2].cooldown;
    }

    void CheckAbility(int index)
    {
        if (readyToUse)
        {
            if (index == 0)
                UseAbility(collection[indexAbility1], indexAbility1, index);
            else if (index == 1)
                UseAbility(collection[indexAbility2], indexAbility2, index);
        }
    }

    void UseAbility(AbilityList ability, int index, int whichUI)
    {
        Ability parametrs = ability.abilityGameObject.GetComponent<Ability>();
        parametrs.Initialization(ability.tier, index, ability.cooldown);
        cooldownSliders[whichUI].maxValue = parametrs.GetAbilityCooldown(ability.tier);
        ability.abilityGameObject.SetActive(true);
    }

    public void SlotChange()
    {
        Ability parametrs = collection[indexAbility1].abilityGameObject.GetComponent<Ability>();
        cooldownSliders[0].maxValue = parametrs.GetAbilityCooldown(collection[indexAbility1].tier);
        backgroudToSlider[0].sprite = collection[indexAbility1].UIRepresentation;
        
        Ability parametrs2 = collection[indexAbility2].abilityGameObject.GetComponent<Ability>();
        cooldownSliders[1].maxValue = parametrs2.GetAbilityCooldown(collection[indexAbility2].tier);
        backgroudToSlider[1].sprite = collection[indexAbility2].UIRepresentation;

        PlayerPrefs.SetInt("Ability_Index_1", indexAbility1);
        PlayerPrefs.SetInt("Ability_Index_2", indexAbility2);

        RefreshingAllCooldowns();
    }

    public void RefreshingCooldown(int indexAbility)
    {
        if (indexAbility == indexAbility1)
            collection[indexAbility1].cooldown = 0.0f;
        else if (indexAbility == indexAbility2)
            collection[indexAbility2].cooldown = 0.0f;

        readyToUse = true;
    }

    public void RefreshingAllCooldowns()
    {
        collection[indexAbility1].cooldown = 0.0f;
        collection[indexAbility2].cooldown = 0.0f;

        readyToUse = true;
    }
}

[System.Serializable]
public class AbilityList
{
    public GameObject abilityGameObject;
    public Sprite UIRepresentation;
    public int tier;
    public float cooldown;
}