using UnityEngine;

public class HubReferenceHub : MonoBehaviour
{
    [SerializeField]
    Passive_Shop passiveShop;
    [SerializeField]
    Abilities_Shop abilitiesShop;

    void Start()
    {
        G_Controller.instatnce.abilitiesShopCosts = ((Abilities_Shop)abilitiesShop.Clone()).costsOfAllAspects;
        G_Controller.instatnce.passiveShopCosts = ((Passive_Shop)passiveShop.Clone()).costsOfAllAspects;

    }
}
