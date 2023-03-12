using UnityEngine;

public class InMainMenu : GameStateTempalte
{
    public override void InvokeState() { }

    public override void Start()
    {
        G_Controller.instatnce.UIController.pauseMenu.SetActive(false);
        G_Controller.instatnce.UIController.playerWalletUI.SetActive(false);
        G_Controller.instatnce.PlayerHealth.HP = G_Controller.instatnce.PlayerHealth.maxHP;
    }

    public override void Update() { }
}
