using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_UI_Controller : MonoBehaviour
{
    [Header("Components of shop")]
    public GameObject abilitiesPurchasesUI;
    public GameObject passivePurchasesUI;
    public GameObject abilityEquipUI;

    [Header("List of skills UI icons")]
    [SerializeField]
    List<Image> abilityImages;

    [Header("Abilities Button")]
    [SerializeField]
    Button abilitiesButton;

    private void OnEnable()
    {
        ShopInitialization(true);
    }

    private void OnDisable()
    {
        ShopInitialization(false);
    }

    void ShopInitialization(bool state)
    {
        abilitiesPurchasesUI.SetActive(true);
        passivePurchasesUI.SetActive(false);
        abilityEquipUI.SetActive(false);

        abilitiesButton.Select();

        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, !state);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, !state);

        G_Controller.instatnce.UIController.playerWalletUI.SetActive(!state);
    }

    public void ExitShop()
    {
        gameObject.SetActive(false);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Click_Button");
    }

    public void ChangeToPassive()
    {
        passivePurchasesUI.SetActive(true);
        abilitiesPurchasesUI.SetActive(false);
        abilityEquipUI.SetActive(false);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Click_Button");
    }

    public void ChangeToActive()
    {
        passivePurchasesUI.SetActive(false);
        abilitiesPurchasesUI.SetActive(true);
        abilityEquipUI.SetActive(false);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Click_Button");
    }

    public void EquipUISwitch(bool state)
    {
        abilityEquipUI.SetActive(state);
        abilitiesPurchasesUI.SetActive(!state);

        if (!state) return;

        abilityImages[0].sprite = G_Controller.instatnce.PlayerSkills.collection[G_Controller.instatnce.PlayerSkills.indexAbility1].UIRepresentation;
        abilityImages[1].sprite = G_Controller.instatnce.PlayerSkills.collection[G_Controller.instatnce.PlayerSkills.indexAbility2].UIRepresentation;
    }
}
