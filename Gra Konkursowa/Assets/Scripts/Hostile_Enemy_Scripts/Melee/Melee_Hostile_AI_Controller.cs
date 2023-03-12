using UnityEngine;
public class Melee_Hostile_AI_Controller : Hostile_AI
{
    [Header("Hitbox")]
    [SerializeField] private GameObject Hitbox;
    [SerializeField] private float Hitbox_Radius;

    [Header("Sound effects")]
    bool soundPlayed;

    private void Update()
    {
        ActivateAI();
    }

    protected override void TypeOfAttack()
    {
        base.TypeOfAttack();

        Collider[] playerColider = Physics.OverlapSphere(Hitbox.transform.position, Hitbox_Radius);

        soundPlayed = false;

        foreach (Collider hit in playerColider)
        {
            if (hit.tag == "Player")
            {
                G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Hostile_Melee_Hits_Player");
                soundPlayed = true;
                hit.GetComponent<Health>().HP -= damage;
                playerColider = null;
                break;
            }

            else if (!soundPlayed)
            {
                G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Hostile_Melee_Slash");
                soundPlayed = true;
            }
        }
    }
}

