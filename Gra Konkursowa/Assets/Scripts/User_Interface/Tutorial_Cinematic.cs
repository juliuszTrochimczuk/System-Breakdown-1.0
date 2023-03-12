using UnityEngine;

public class Tutorial_Cinematic : MonoBehaviour
{
    [Header("Skip text")]
    [SerializeField]
    GameObject skipButton;
    bool pressed = false;

    private void Start() => G_Controller.instatnce.inputs.Other_Map.Interaction.performed += _ => Skip();

    public void StartingCinematic()
    {
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Tutorial_Music");

        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Menu, false);

        G_Controller.instatnce.UIController.combatUI.SetActive(false);
    }

    public void EndingCinematic()
    {
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, true);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, true);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Menu, true);

        G_Controller.instatnce.inputs.Other_Map.Interaction.canceled += _ => Skip();

        G_Controller.instatnce.UIController.PreparingForLoading("Tutorial_Metro");
    }

    void Skip()
    {
        if (!pressed)
        {
            skipButton.SetActive(false);
            EndingCinematic();
            pressed = true;
        }
    }
}
