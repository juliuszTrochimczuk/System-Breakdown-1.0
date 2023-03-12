using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameStateTempalte CurrentState
    {
        get
        {
            return current;
        }
        set
        {
            current = value;
            current.Start();
        }
    }
    private GameStateTempalte current;
    public InTheHub inTheHubState = new InTheHub();
    public OnTheArena onTheArenaState = new OnTheArena();
    public GamePaused gamePausedState = new GamePaused();
    public LoadingScene loadingSceneState = new LoadingScene();
    public InMainMenu inMainMenu = new InMainMenu();

    void Start()
    {
        CurrentState = loadingSceneState;
    }

    void Update()
    {
        CurrentState.Update();
    }

    public void PressPause()
    {
        CurrentState.InvokeState();
    }
}
