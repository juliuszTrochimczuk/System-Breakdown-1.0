using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UI_Controller : MonoBehaviour
{
    [Header("Combat UI")]
    public GameObject combatUI;
    public Animator combatUIAnimator;
    public TextMeshProUGUI ability_1, ability_2;

    [Header("Player Wallet UI")]
    public GameObject playerWalletUI;
    public TextMeshProUGUI scrapWallet;
    public TextMeshProUGUI skillPointsWallet;

    [Header("Note UI")]
    public GameObject PaperUI;
    public Image paperText;

    [Header("Dialog UI")]
    public Dialog_UI dialogUI;

    [Header("Door Popup")]
    public GameObject doorPopup;

    [Header("Pause Menu")]
    public GameObject pauseMenu;
    [SerializeField]
    GameObject mainPauseMenu;
    [SerializeField]
    GameObject settingsMenuInPause;

    [Header("Animation of loading scene")]
    public Animator loadingEffect;

    [Header("Canvas for loading scenes")]
    public GameObject sceneLoaderCanvas;

    [Header("Player Death Canvas")]
    [SerializeField]
    GameObject deathCanvas;

    [Header("Arena Information")]
    public TextMeshProUGUI enemyCounter;
    public TextMeshProUGUI difficultyText;

    [Header("Console")]
    public TTY tty;


    private void Awake()
    {
        G_Controller.instatnce.inputs.Menu_Map.OpenConsole.performed += tty.OpenConsole_performed;
        DontDestroyOnLoad(gameObject);
    }

    private void Start() => G_Controller.instatnce.inputs.Menu_Map.Open_Pause_Menu.performed += _ => CheckPause();

    public void PreparingForLoading(string nameOfScene = "", bool showSceneEnding = true, bool nameDirect = false) => StartCoroutine(LoadingSceneEffect(nameOfScene, showSceneEnding, nameDirect));

    IEnumerator LoadingSceneEffect(string whichScene = "", bool showEnding = true, bool nameDirect = false)
    {
        ability_1.text = G_Controller.instatnce.inputs.asset["Use_Ability_1"].GetBindingDisplayString().ToUpper();
        ability_2.text = G_Controller.instatnce.inputs.asset["Use_Ability_2"].GetBindingDisplayString().ToUpper();

        if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.onTheArenaState)
        {
            combatUIAnimator.SetTrigger("Disappearing_Combat_UI");
            yield return new WaitForSeconds(0.75f);
        }

        if (showEnding)
        {
            loadingEffect.SetBool("End_Scene", true);

            yield return new WaitForSeconds(1);

            loadingEffect.SetBool("End_Scene", false);
        }

        G_Controller.instatnce.gameStateManager.CurrentState = G_Controller.instatnce.gameStateManager.loadingSceneState;

        if (!nameDirect)
        {
            switch (whichScene)
            {
                case "":
                    G_Controller.instatnce.LoadNewArena();
                    break;
                case "Hub":
                    G_Controller.instatnce.LoadingNewScene("Hub");
                    break;
                case "Main_Menu":
                    G_Controller.instatnce.LoadingNewScene("Main_Menu");
                    break;
                case "Intro":
                    G_Controller.instatnce.LoadingNewScene("Intro");
                    break;
                case "Tutorial_Metro":
                    G_Controller.instatnce.LoadingNewScene("tutorial_metro");
                    break;
            }
        }
        else G_Controller.instatnce.LoadingNewScene(whichScene);

        while (!G_Controller.instatnce.loadSceneOp.isDone) yield return new WaitForEndOfFrame();

        loadingEffect.SetBool("Start_Scene", true);

        yield return new WaitForSeconds(1);

        loadingEffect.SetBool("Start_Scene", false);

        if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.onTheArenaState)
        {
            yield return new WaitForSeconds(0.5f);
            combatUIAnimator.SetTrigger("Appearing_Combat_UI");
        }
    }

    public void CheckPause()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Hub")
        {
            Shop_UI_Controller shopCanvas = Resources.FindObjectsOfTypeAll<Shop_UI_Controller>()[0];
            if (shopCanvas.gameObject.activeInHierarchy) shopCanvas.ExitShop();
            else
            {
                if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.inTheHubState) G_Controller.instatnce.gameStateManager.CurrentState = G_Controller.instatnce.gameStateManager.gamePausedState;
                else G_Controller.instatnce.gameStateManager.CurrentState = G_Controller.instatnce.gameStateManager.inTheHubState;
            }
        }
        else if (G_Controller.instatnce.gameStateManager.CurrentState != G_Controller.instatnce.gameStateManager.inMainMenu
            && G_Controller.instatnce.gameStateManager.CurrentState != G_Controller.instatnce.gameStateManager.loadingSceneState)
        {
            if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.onTheArenaState) G_Controller.instatnce.gameStateManager.CurrentState = G_Controller.instatnce.gameStateManager.gamePausedState;
            else
            {
                G_Controller.instatnce.gameStateManager.CurrentState = G_Controller.instatnce.gameStateManager.onTheArenaState;
                combatUIAnimator.SetTrigger("Appearing_Combat_UI");
            }
        }

        G_Controller.instatnce.gameStateManager.CurrentState.InvokeState();
    }

    public void ShowDeathCanvas()
    {
        loadingEffect.SetTrigger("End_Scene");

        deathCanvas.SetActive(true);
    }

    public void SettingsMenuState(bool state)
    {
        settingsMenuInPause.SetActive(state);
        mainPauseMenu.SetActive(!state);
    }

    public void ButtonSoundEffect() => G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Click_Button");
}
