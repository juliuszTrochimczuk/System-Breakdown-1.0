using UnityEngine;
using TMPro;

public class Death_UI : MonoBehaviour
{
    [Header("Statistics of player on death canvas")]
    [SerializeField]
    TextMeshProUGUI BestScore;
    [SerializeField]
    TextMeshProUGUI ActualScore;
    [SerializeField]
    TextMeshProUGUI scrapEarned;
    [SerializeField]
    TextMeshProUGUI reviveButton;
    [SerializeField]
    public TMP_Text unlocks;
    string iniztialUnlockString;

    private void OnEnable()
    {
        iniztialUnlockString = unlocks.text;
        if (G_Controller.instatnce.abilitiesShopCosts != null)
        {
            for (int i = 0; i < G_Controller.instatnce.abilitiesShopCosts.Count; i++)
            {
                if (G_Controller.instatnce.abilitiesShopCosts[i].cost.Count > G_Controller.instatnce.PlayerSkills.collection[i].tier + 1 && G_Controller.instatnce.PlayerMoney.Scrap >= G_Controller.instatnce.abilitiesShopCosts[i].cost[G_Controller.instatnce.PlayerSkills.collection[i].tier + 1])
                {
                    unlocks.text += "\n";
                    switch (i)
                    {
                        case 0:
                            unlocks.text += "rocket";
                            break;
                        case 1:
                            unlocks.text += "shield";
                            break;
                        case 2:
                            unlocks.text += "time freeze";
                            break;
                        case 3:
                            unlocks.text += "stun";
                            break;
                    }
                    unlocks.text += " lvl " + (G_Controller.instatnce.PlayerSkills.collection[i].tier + 2).ToString();
                }
            }
        }
        if (G_Controller.instatnce.passiveShopCosts != null)
        {
            for (int i = 0; i < G_Controller.instatnce.passiveShopCosts.Count; i++)
            {
                if (G_Controller.instatnce.passiveShopCosts[i].cost.Count > G_Controller.instatnce.PlayerPassive.listOfTiers[i] && G_Controller.instatnce.PlayerExperience.SkillPoints >= G_Controller.instatnce.passiveShopCosts[i].cost[G_Controller.instatnce.PlayerPassive.listOfTiers[i]])
                {
                    unlocks.text += "\n";
                    switch (i)
                    {
                        case 0:
                            unlocks.text += "health";
                            break;
                        case 1:
                            unlocks.text += "dash cooldown";
                            break;
                        case 2:
                            unlocks.text += "ammo capacity";
                            break;
                    }
                    unlocks.text += " upgrade";
                }
            }
        }
        unlocks.gameObject.SetActive(unlocks.text != iniztialUnlockString);

        BestScore.text = G_Controller.instatnce.SaveData.bestScore.ToString();
        ActualScore.text = G_Controller.instatnce.PlayerScore.Score.ToString();
        scrapEarned.text = G_Controller.instatnce.PlayerMoney.scrapEarned.ToString();

        if (!G_Controller.instatnce.SaveData.tutorialDone) reviveButton.text = "Revive";
        else reviveButton.text = "Return to Hub";

        Cursor.visible = true;
    }

    void QuitingDeathCanvas()
    {
        gameObject.SetActive(false);
        if (G_Controller.instatnce.PlayerScore.Score > G_Controller.instatnce.SaveData.bestScore)
        {
            G_Controller.instatnce.SaveData.bestScore = G_Controller.instatnce.PlayerScore.Score;
            BestScore.text = G_Controller.instatnce.PlayerScore.Score.ToString();
        }
    }

    public void RevivePlayer()
    {
        QuitingDeathCanvas();
        if (!G_Controller.instatnce.SaveData.tutorialDone)
        {
            G_Controller.instatnce.UIController.PreparingForLoading(nameOfScene: "Tutorial_Metro");
            G_Controller.instatnce.PlayerHealth.HP = G_Controller.instatnce.PlayerHealth.maxHP;
            G_Controller.instatnce.PlayerScore.ResetScore();
            G_Controller.instatnce.PlayerShooting.AmmoChanging(25);
        }
        else G_Controller.instatnce.UIController.PreparingForLoading(nameOfScene: "Hub");
    }

    public void QuitToMenu()
    {
        QuitingDeathCanvas();
        G_Controller.instatnce.UIController.PreparingForLoading("Main_Menu", false);
        G_Controller.instatnce.AudioPlayer.ResetAllAudio();
        AudioListener.pause = false;
        G_Controller.instatnce.UIController.sceneLoaderCanvas.SetActive(true);
        G_Controller.instatnce.gameStateManager.CurrentState = G_Controller.instatnce.gameStateManager.gamePausedState;
    }
}
