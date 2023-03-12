using UnityEngine;

public class Paper_Note_UI : MonoBehaviour
{
    public void NoteExit()
    {
        G_Controller.instatnce.UIController.PaperUI.SetActive(false);

        if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.onTheArenaState)
        {
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, true);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, true);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, true);
        }
        else if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.inTheHubState)
        {
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, true);
            G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, true);
        }
    }
}
