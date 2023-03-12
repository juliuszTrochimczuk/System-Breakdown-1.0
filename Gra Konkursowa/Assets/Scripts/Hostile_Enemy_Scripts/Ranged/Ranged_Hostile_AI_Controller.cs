using UnityEngine;

public class Ranged_Hostile_AI_Controller : Hostile_AI
{
    [Header("Attack System")]
    [SerializeField]
    private GameObject Hostile_AI_Bullet;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float BulletSpeed;

    private void Update()
    {
        ActivateAI();
    }

    protected override void TypeOfAttack()
    {
        base.TypeOfAttack();

        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Hostile_Shoot_One_Bullet");

        GameObject Bullet_gameObject = Instantiate(Hostile_AI_Bullet, firePoint.position, transform.rotation);
        Bullet_gameObject.GetComponent<BulletController>().damage = damage;

        Bullet_gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * BulletSpeed, ForceMode.Impulse);
    }
}

    