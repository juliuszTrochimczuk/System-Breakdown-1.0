using UnityEngine;
using TMPro;

public class Interphase : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI stage;

    void Start()
    {
        stage.text = (G_Controller.instatnce.difficulty - 1).ToString() + stage.text.Substring(1);

        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Combat, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Movement, false);
        G_Controller.instatnce.PlayerActionMapControlls(G_Controller.InputMaps.Other, false);
    }
}
