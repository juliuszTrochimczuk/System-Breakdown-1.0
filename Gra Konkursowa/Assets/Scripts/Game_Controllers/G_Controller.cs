using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class G_Controller : MonoBehaviour
{
    public static G_Controller instatnce { get; set; }
    public Player_Actions inputs { get; set; }
    public enum InputMaps { Movement, Combat, Menu, Other  }

    public GameStateManager gameStateManager;

    public IInteractable lastInteraction;

    [Header("List of all arenas and controlling variables")]
    [SerializeField]
    List<ListOfArenas> listOfArenas;
    public int stage;
    public int vibe;
    List<string> poolOfArenas;
    public int difficulty = 1;
    string lastPlayedArena;

    [Header("Random component")]
    System.Random random = new System.Random();

    [Header("Player Transform")]
    public Transform player;
    public Transform playersModelTransform;
    static GameObject playerInstance;

    [Header("Player Experience")]
    [SerializeField]
    P_Experience playerExperience;
    public P_Experience PlayerExperience => playerExperience;

    [Header("Player Skills")]
    [SerializeField]
    P_Skills playerSkills;
    public P_Skills PlayerSkills => playerSkills;

    [Header("Player Movement")]
    [SerializeField]
    P_MovementController playerMovement;
    public P_MovementController PlayerMovement => playerMovement;

    [Header("Player shooting")]
    [SerializeField]
    P_Shooting playerShooting;

    public P_Shooting PlayerShooting => playerShooting;

    [Header("Player health")]
    [SerializeField]
    P_Health playerHealth;
    public P_Health PlayerHealth => playerHealth;
    public GameObject syringe;

    [Header("Player Passive Tiers")]
    [SerializeField]
    Passive_Tiers playerPassive;
    public Passive_Tiers PlayerPassive => playerPassive;

    [Header("Player Money")]
    [SerializeField]
    Money money;
    public Money PlayerMoney => money;

    [Header("Player score")]
    [SerializeField]
    P_Score score;
    public P_Score PlayerScore => score;

    [Header("Audio Manager")]
    [SerializeField]
    Audio_Manager audioPlayer;
    public Audio_Manager AudioPlayer => audioPlayer;

    [Header("UI Controller")]
    [SerializeField]
    UI_Controller uiController;
    public UI_Controller UIController => uiController;

    [Header("Audio Mixer")]
    [SerializeField]
    AudioMixer audioMixer;
    public AudioMixer AudioMixer => audioMixer;

    [Header("Scene Mangement")]
    public AsyncOperation loadSceneOp;
    public CanvasGroup levelLoader;
    public Arena_Controller arenaController;

    [Header("Difficulty multipliers")]
    public float difficultyHPMultiplier;
    public float difficultyDamageMultiplier;
    public float difficultyMoneyMultiplier;
    public float difficultyXPMultiplier;

    [Header("Cheats")]
    private bool godmode = false;

    [Header("Shops")]
    public List<Costs> abilitiesShopCosts;
    public List<Costs> passiveShopCosts;
    public bool Godmode
    {
        get
        {
            return godmode;
        }
        set
        {
            if (value)
            {
                playerShooting.baseDamage *= 1024;
            }
            else
            {
                playerShooting.baseDamage /= 1024;
            }
            godmode = value;
            PlayerHealth.invincible = value;
        }
    }

    [Header("Player save data")]
    [SerializeField]
    P_Save save;
    public P_Save SaveData => save;

    private void Awake()
    {
        if (instatnce == null)
            instatnce = this;
        else Destroy(gameObject);

        if (playerInstance == null)
            playerInstance = player.gameObject;
        else Destroy(player.gameObject);

        if (inputs == null)
            inputs = new Player_Actions();

        poolOfArenas = new List<string>(listOfArenas[vibe].nameOfArenas);



        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(player.gameObject);
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void Start()
    {
        SettingPlayerVariables();
    }

    public void PlayerActionMapControlls(InputMaps map, bool state)
    {
        switch (map)
        {
            case InputMaps.Movement:
                if (state) inputs.Movement_Map.Enable();
                else inputs.Movement_Map.Disable();
                break;
            case InputMaps.Combat:
                if (state) inputs.Combat_Map.Enable();
                else inputs.Combat_Map.Disable();
                break;
            case InputMaps.Menu:
                if (state) inputs.Menu_Map.Enable();
                else inputs.Menu_Map.Disable();
                break;
            case InputMaps.Other:
                if (state) inputs.Other_Map.Enable();
                else inputs.Other_Map.Disable();
                break;
        }    
    }

    public void LoadNewArena()
    {
        if (stage >= listOfArenas[vibe].maxStage)
        {
            audioPlayer.PlayOrStopAudio("Comunistic_Arena_Music", false);
            audioPlayer.PlayOrStopAudio("Cyberpunk_Arena_Music", false);

            if (vibe + 1 == listOfArenas.Count)
            {
                vibe = 0;
                difficulty += 1;

                uiController.difficultyText.text = difficulty.ToString();
                if (difficulty == 4)
                {
                    LoadingNewScene("Ending");
                    return;
                }
                else
                {
                    LoadingNewScene("Interphase");
                    stage = 0;
                    return;
                }
            }
            else vibe += 1;

            stage = 0;
        }
        if (stage == 0)
        {
            poolOfArenas = new List<string>(listOfArenas[vibe].nameOfArenas);
            LoadMusic();
        }
        else poolOfArenas.Remove(SceneManager.GetActiveScene().name);

        if (stage == 0 && vibe == 0 && difficulty == 1 && lastPlayedArena != "")
            if (poolOfArenas.Contains(lastPlayedArena)) poolOfArenas.Remove(lastPlayedArena);

        int draw = random.Next(0, poolOfArenas.Count);
        stage += 1;

        lastPlayedArena = poolOfArenas[draw];

        loadSceneOp = SceneManager.LoadSceneAsync(poolOfArenas[draw]);
        instatnce.gameStateManager.CurrentState = instatnce.gameStateManager.loadingSceneState;
    }

    public void LoadingNewScene(string nameOfScene)
    {
        loadSceneOp = SceneManager.LoadSceneAsync(nameOfScene);
        instatnce.gameStateManager.CurrentState = instatnce.gameStateManager.loadingSceneState;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 2) instatnce.gameStateManager.CurrentState = instatnce.gameStateManager.inTheHubState;
        else if (level == 1)
        {
            instatnce.PlayerSkills.RefreshingAllCooldowns();
            instatnce.gameStateManager.CurrentState = instatnce.gameStateManager.inMainMenu;
        }
        else instatnce.gameStateManager.CurrentState = instatnce.gameStateManager.onTheArenaState;

        Vector3 newPlayerPosition = FindObjectOfType<Position_P_initizalization>().playerInitialization.position;
        player.position = newPlayerPosition;
        player.GetChild(0).position = newPlayerPosition;
        arenaController = GameObject.Find("Arena_Controller").GetComponent<Arena_Controller>();
    }

    void LoadMusic()
    {
        if (stage == 0)
        { 
            if (vibe == 0) audioPlayer.PlayOrStopAudio("Comunistic_Arena_Music");
            else if (vibe == 2) audioPlayer.PlayOrStopAudio("Cyberpunk_Arena_Music");
        }
    }

    private void OnDisable()
    {
        inputs.Disable();
    }

    public void SettingPlayerVariables()
    {
        PlayerPassive.SettingPassive();
        playerHealth.maxHP = playerPassive.maxHealthValue[PlayerPassive.listOfTiers[0]];
        playerHealth.HP = playerHealth.maxHP;
        playerMovement.P_dash_cooldown = playerPassive.dashCooldownValue[PlayerPassive.listOfTiers[1]];
        playerShooting.AmmoChanging(playerPassive.maxAmmoValue[PlayerPassive.listOfTiers[2]]);
    }

    public void ResetPlayerProgress()
    {
        PlayerPrefs.SetInt("Best_Score", 0);

        G_Controller.instatnce.PlayerMoney.Scrap = 0;

        G_Controller.instatnce.PlayerExperience.SkillPoints = 0;
        G_Controller.instatnce.PlayerExperience.XP = 0;
        G_Controller.instatnce.PlayerExperience.level = 1;
        G_Controller.instatnce.PlayerExperience.ResetingProgress();

        G_Controller.instatnce.PlayerPassive.listOfTiers[0] = 0;
        G_Controller.instatnce.PlayerPassive.listOfTiers[1] = 0;
        G_Controller.instatnce.PlayerPassive.listOfTiers[2] = 0;
        G_Controller.instatnce.SettingPlayerVariables();

        G_Controller.instatnce.PlayerSkills.collection[0].tier = 0;
        G_Controller.instatnce.PlayerSkills.collection[1].tier = 0;
        G_Controller.instatnce.PlayerSkills.collection[2].tier = -1;
        G_Controller.instatnce.PlayerSkills.collection[3].tier = -1;
        G_Controller.instatnce.PlayerSkills.indexAbility1 = 0;
        G_Controller.instatnce.PlayerSkills.indexAbility2 = 1;
        G_Controller.instatnce.PlayerSkills.SlotChange();
    }
}


[System.Serializable]
public class ListOfArenas
{
    public List<string> nameOfArenas;
    public int maxStage;
}