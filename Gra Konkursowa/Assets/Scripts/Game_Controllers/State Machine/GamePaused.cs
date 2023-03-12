using UnityEngine;

public class GamePaused : GameStateTempalte
{
    public override void InvokeState()
    {
        G_Controller.instatnce.UIController.sceneLoaderCanvas.SetActive(false);
        AudioListener.pause = true;
        Time.timeScale = 0.0f;

        G_Controller.instatnce.UIController.pauseMenu.SetActive(true);

        Cursor.visible = true;
    }

    public override void Start()
    {
        G_Controller.instatnce.UIController.combatUI.SetActive(false);
       
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, false);

        if (G_Controller.instatnce.lastInteraction is Digital_Code_Lock_Controller)
        {
            Digital_Code_Lock_Controller keyPad = G_Controller.instatnce.lastInteraction as Digital_Code_Lock_Controller;
            if (keyPad.ShouldBeActive)
            {
                keyPad.ExitTerminal();
            }
        }
    }

    public override void Update() { }
}