using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("List of costs of all aspects")]
    [SerializeField]
    public List<Costs> costsOfAllAspects;

    [Header("Error message")]
    [SerializeField]
    protected GameObject errorMessage;

    [Header("Cost texts")]
    [SerializeField]
    protected List<UIRepresentation> upgradeUIElement;

    [Header("Ui constroller")]
    [SerializeField]
    protected Shop_UI_Controller uiController;

    [Header("How many currency player have")]
    [SerializeField]
    protected TextMeshProUGUI playerCurrencyDisplay;

    [Header("Equip buttons")]
    [SerializeField]
    protected List<Button> equipButton;

    private void OnEnable()
    {
        for (int i = 0; i < upgradeUIElement.Count; i++)
        {
            UpdateCostText(i);
        }
    }

    protected void UpdateCostText(int index)
    {
        if (uiController.passivePurchasesUI.activeInHierarchy)
        {
            if (G_Controller.instatnce.PlayerPassive.listOfTiers[index] == costsOfAllAspects[index].cost.Count)
                MaxUpdateCell(index);
            else upgradeUIElement[index].costsText.text = costsOfAllAspects[index].cost[G_Controller.instatnce.PlayerPassive.listOfTiers[index]].ToString();
            playerCurrencyDisplay.text = "Skill Points: " + G_Controller.instatnce.PlayerExperience.SkillPoints.ToString();
        }
        else
        {
            if (G_Controller.instatnce.PlayerSkills.collection[index].tier == costsOfAllAspects[index].cost.Count - 1)
                MaxUpdateCell(index);
            else
            {
                upgradeUIElement[index].costsText.text = costsOfAllAspects[index].cost[G_Controller.instatnce.PlayerSkills.collection[index].tier + 1].ToString();
                if (G_Controller.instatnce.PlayerSkills.collection[index].tier == -1)
                {
                    upgradeUIElement[index].upgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy";
                    equipButton[index].interactable = false;
                    equipButton[index].colors.Equals(Color.gray);
                }
                else
                {
                    upgradeUIElement[index].upgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "Upgrade";
                    equipButton[index].interactable = true;
                    equipButton[index].colors.Equals(Color.white);
                }
            }
            playerCurrencyDisplay.text = "Scrap: " + G_Controller.instatnce.PlayerMoney.Scrap.ToString();
        }
    }

    protected void ShowErrorMessage()
    {
        StartCoroutine(errorAnimation());
    }

    IEnumerator errorAnimation()
    {
        errorMessage.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        errorMessage.SetActive(false);
    }

    private void MaxUpdateCell(int index)
    {
        upgradeUIElement[index].costsText.text = "MAX";
        upgradeUIElement[index].upgradeButton.interactable = false;
        upgradeUIElement[index].upgradeButton.colors.Equals(Color.gray);
    }
}

[System.Serializable]
public class Costs
{
    public List<int> cost;
}

[System.Serializable]
public class UIRepresentation
{
    public TextMeshProUGUI costsText;
    public Button upgradeButton;
}