using UnityEngine;

public class InTheHub : GameStateTempalte
{
    public override void InvokeState() { }

    public override void Start()
    {
      
        G_Controller.instatnce.UIController.sceneLoaderCanvas.SetActive(true);

        AudioListener.pause = false;

        Time.timeScale = 1.0f;

        G_Controller.instatnce.UIController.pauseMenu.SetActive(false);
        G_Controller.instatnce.UIController.playerWalletUI.SetActive(true);

        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, true);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Menu, true);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, true);

        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Cyberpunk_Arena_Music", false);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Comunistic_Arena_Music", false);

        G_Controller.instatnce.PlayerSkills.RefreshingAllCooldowns();
        G_Controller.instatnce.SettingPlayerVariables();

        G_Controller.instatnce.PlayerHealth.HP = G_Controller.instatnce.PlayerHealth.maxHP;

        G_Controller.instatnce.PlayerMovement.P_MoveSpeed = G_Controller.instatnce.PlayerMovement.hubSpeed;

        G_Controller.instatnce.PlayerMoney.scrapEarned = 0;

        G_Controller.instatnce.PlayerScore.ResetScore();

        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Hub_Music");

        G_Controller.instatnce.stage = 0;
        G_Controller.instatnce.vibe = 0;
        G_Controller.instatnce.difficulty = 1;

        if (G_Controller.instatnce.lastInteraction is Digital_Code_Lock_Controller)
        {
            Digital_Code_Lock_Controller keyPad = G_Controller.instatnce.lastInteraction as Digital_Code_Lock_Controller;
            if (keyPad.ShouldBeActive)
            {
                keyPad.OpenTerminal();
            }
        }
    }

    public override void Update() { }
}
