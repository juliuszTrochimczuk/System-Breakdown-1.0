using UnityEngine;

public class OnTheArena : GameStateTempalte
{
    public override void InvokeState() {}

    public override void Start()
    {
       
        G_Controller.instatnce.UIController.sceneLoaderCanvas.SetActive(true);

        AudioListener.pause = false;

        G_Controller.instatnce.UIController.sceneLoaderCanvas.SetActive(true);

        Time.timeScale = 1.0f;

        G_Controller.instatnce.UIController.pauseMenu.SetActive(false);
        G_Controller.instatnce.UIController.playerWalletUI.SetActive(false);

        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, true);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, true);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, true);

        G_Controller.instatnce.PlayerMovement.P_MoveSpeed = G_Controller.instatnce.PlayerMovement.arenaSpeed;
        
        G_Controller.instatnce.UIController.combatUI.SetActive(true);
        G_Controller.instatnce.UIController.doorPopup.SetActive(false);
    }

    public override void Update()
    {
        G_Controller.instatnce.PlayerSkills.LoadingAbilities();
    }
}