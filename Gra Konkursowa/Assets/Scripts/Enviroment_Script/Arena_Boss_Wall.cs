using UnityEngine;

public class Arena_Boss_Wall : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    bool entered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !entered)
        {
            Door doorComponent = door.GetComponent<Door>();
            Destroy(doorComponent);
            G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Boss_Arena_Door_Locked");
            G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Boss_Arena_Music");
            entered = true;
        }
    }
}
