using UnityEngine;
using UnityEngine.VFX;

public class P_Rocket : MonoBehaviour
{
    [Header("Move speed variable")]
    [SerializeField]
    float moveSpeed;

    [Header("Explosion effect")]
    [SerializeField]
    VisualEffect explosionEffect;
    [SerializeField]
    MeshRenderer material;
    [SerializeField]
    ParticleSystem smokeEffect;

    [Header("variables to explosion")]
    public bool exploded = false;
    [HideInInspector]
    public float radius;
    [SerializeField]
    float sphereCheck;
    [HideInInspector]
    public int damage;

    private void Start()
    {
        explosionEffect.SetFloat("SizeOfExplosion", radius);
    }

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, sphereCheck);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Enemy") && !exploded)
            {
                Explosion(hit.transform.position);
                break;
            }
        }

        if (!exploded)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.collider.CompareTag("Player") && !other.collider.CompareTag("Enemy_Bullet") && !exploded && other.collider.gameObject.layer != 2)
            Explosion(transform.position);
    }

    void ExplosionEffect(Vector3 effectPosition)
    {
        GameObject createdEffect = Instantiate(explosionEffect.gameObject, effectPosition, Quaternion.identity);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Rocket_Explosion");
        Destroy(createdEffect, 3f);
        Destroy(gameObject, 3f);
    }

    public void Explosion(Vector3 hitPosition)
    {
        ExplosionEffect(hitPosition);

        material.enabled = false;
        exploded = true;

        int kills = 0;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var hitted in hitColliders)
        {
            if (hitted.gameObject.CompareTag("Enemy"))
            {
                Health enemyHealth = hitted.gameObject.GetComponent<Health>();
                enemyHealth.HP -= damage;
                if (enemyHealth.HP <= 0) kills++;
            }
            else if (hitted.gameObject.CompareTag("DestructableObject"))
            {
                Health enemyHealth = hitted.gameObject.GetComponent<Health>();
                enemyHealth.HP -= damage;
            }
        }

        if (kills == 1) G_Controller.instatnce.PlayerScore.GrantScore(ScoreChangingActions.KilledWithRocket);
        else if (kills > 1) for (int i = 0; i < kills; i++ ) G_Controller.instatnce.PlayerScore.GrantScore(ScoreChangingActions.KilledGroupWithRocket);

        smokeEffect.Stop();
    }
}
