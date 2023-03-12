using UnityEngine;

public class Money : MonoBehaviour
{
    public int scrapEarned;

    private void Start()
    {
        Scrap = G_Controller.instatnce.SaveData.money;
    }

    public long Scrap
    {
        get
        {
            return scrap;
        }
        set
        {
            if (value < 0) throw new NotEnoughMoneyEception();
            scrap = value;
            G_Controller.instatnce.UIController.scrapWallet.text = scrap.ToString();
            G_Controller.instatnce.SaveData.money = (int)scrap;
        }
    }

    public long scrap;
}
