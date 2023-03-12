using System.Collections.Generic;
using UnityEngine;

public class Ranged_Boss : Hostile_AI
{
    [Header("Attack System")]
    [SerializeField]
    private GameObject Hostile_AI_Bullet;
    [SerializeField]
    private List<Transform> firePoints;
    [SerializeField]
    private float BulletSpeed;

    [Header("Animator canvas")]
    [SerializeField]
    Animator ending;

    private void Update() => ActivateAI();

    protected override void TypeOfAttack()
    {
        base.TypeOfAttack();

        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Hostile_Shoot_Shotgun");

        foreach (Transform firePoint in firePoints)
        {
            GameObject Bullet_gameObject = Instantiate(Hostile_AI_Bullet, firePoint.position, firePoint.rotation);

            Bullet_gameObject.GetComponent<BulletController>().damage = damage;

            Bullet_gameObject.GetComponent<Rigidbody>().AddForce(Bullet_gameObject.transform.forward * BulletSpeed, ForceMode.Impulse);
        }
    }

    public void BossDeath() => ending.SetTrigger("Boss Killed");
}
