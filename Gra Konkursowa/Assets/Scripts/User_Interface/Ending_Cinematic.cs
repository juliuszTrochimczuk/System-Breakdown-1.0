using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Cinematic : MonoBehaviour
{
    public void StartingCinematic()
    {
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Menu, false);
    }

    public void EndingCinematic()
    {
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, true);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, true);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, true);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Menu, true);
    }

    public void MusicOff()
    {
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Boss_Arena_Music", false);
    }
}