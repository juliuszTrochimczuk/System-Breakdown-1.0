using System;
using UnityEngine;

public class Abilities_Shop : Shop, ICloneable
{
    [Header("Ability index variable")]
    int abilityChosen;

    public void Upgrade(int whichAspect)
    {
        if (G_Controller.instatnce.PlayerMoney.Scrap >= costsOfAllAspects[whichAspect].cost[G_Controller.instatnce.PlayerSkills.collection[whichAspect].tier + 1])
        {
            AbilityUpgradingPlayer(whichAspect);

            G_Controller.instatnce.SaveData.activeTiers[whichAspect] = G_Controller.instatnce.PlayerSkills.collection[whichAspect].tier;
        }

        else ShowErrorMessage();
    }

    void AbilityUpgradingPlayer(int whichAspect)
    {
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Upgrading");
        G_Controller.instatnce.PlayerMoney.Scrap -= costsOfAllAspects[whichAspect].cost[G_Controller.instatnce.PlayerSkills.collection[whichAspect].tier + 1];
        G_Controller.instatnce.PlayerSkills.collection[whichAspect].tier += 1;
        G_Controller.instatnce.SettingPlayerVariables();
        UpdateCostText(whichAspect);
    }

    public void PickAbility(int chosen)
    {
        abilityChosen = chosen;
        uiController.EquipUISwitch(true);
    }

    public void EquipAbility(int abilityIndex)
    {
        switch (abilityIndex)
        {
            case 1:
                if (abilityChosen == G_Controller.instatnce.PlayerSkills.indexAbility2) G_Controller.instatnce.PlayerSkills.indexAbility2 = G_Controller.instatnce.PlayerSkills.indexAbility1;
                G_Controller.instatnce.PlayerSkills.indexAbility1 = abilityChosen;
                G_Controller.instatnce.SaveData.indexAbility1 = abilityChosen;
                break;

            case 2:
                if (abilityChosen == G_Controller.instatnce.PlayerSkills.indexAbility1) G_Controller.instatnce.PlayerSkills.indexAbility1 = G_Controller.instatnce.PlayerSkills.indexAbility2;
                G_Controller.instatnce.PlayerSkills.indexAbility2 = abilityChosen;
                G_Controller.instatnce.SaveData.indexAbility2 = abilityChosen;
                break;
        }

        uiController.EquipUISwitch(false);
        G_Controller.instatnce.PlayerSkills.SlotChange();
    }

    public object Clone()
    {
        Abilities_Shop shop = new Abilities_Shop();
        shop.abilityChosen = abilityChosen;
        shop.costsOfAllAspects = costsOfAllAspects;
        shop.equipButton = equipButton;
        shop.errorMessage = errorMessage;
        shop.playerCurrencyDisplay = playerCurrencyDisplay;
        shop.uiController = uiController;
        shop.upgradeUIElement = upgradeUIElement;
        return shop;
    }
}