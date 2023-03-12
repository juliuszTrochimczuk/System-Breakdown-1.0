using System;

public class Passive_Shop : Shop, ICloneable
{
    public void Upgrade(int whichAspect)
    {
        if (G_Controller.instatnce.PlayerExperience.SkillPoints >= costsOfAllAspects[whichAspect].cost[G_Controller.instatnce.PlayerPassive.listOfTiers[whichAspect]]) PassiveUpgradingPlayer(whichAspect);
        else ShowErrorMessage();
    }

    void PassiveUpgradingPlayer(int whichAspect)
    {
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Upgrading");

        G_Controller.instatnce.PlayerExperience.SkillPoints -= costsOfAllAspects[whichAspect].cost[G_Controller.instatnce.PlayerPassive.listOfTiers[whichAspect]];

        G_Controller.instatnce.PlayerPassive.listOfTiers[whichAspect] += 1;
        G_Controller.instatnce.SaveData.passiveTiers[whichAspect] += 1;

        G_Controller.instatnce.SettingPlayerVariables();
        
        UpdateCostText(whichAspect);
    }

    public object Clone()
    {
        Passive_Shop shop = new Passive_Shop();
        shop.costsOfAllAspects = costsOfAllAspects;
        shop.equipButton = equipButton;
        shop.errorMessage = errorMessage;
        shop.playerCurrencyDisplay = playerCurrencyDisplay;
        shop.uiController = uiController;
        shop.upgradeUIElement = upgradeUIElement;
        return shop;
    }
}