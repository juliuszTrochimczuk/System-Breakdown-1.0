using UnityEngine;

public class BulletController : MonoBehaviour
{
    [Header("Bullet Visual Effects")]
    [SerializeField]
    ParticleSystem b_effect;
    ParticleSystemRenderer b_effectRenderer;

    public int damage;

    private void Awake()
    {
        b_effectRenderer = b_effect.GetComponent<ParticleSystemRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("DestructableObject")) collision.collider.GetComponent<Health>().HP -= damage;
        else if (collision.collider.CompareTag("Enemy_Bullet")) return;
        else if (!collision.collider.CompareTag("Enemy"))
        {
            MeshRenderer colliderRenderer = collision.collider.GetComponent<MeshRenderer>();
            if (colliderRenderer != null) b_effectRenderer.material = colliderRenderer.material;
            GameObject hit = Instantiate(b_effect.gameObject, transform.position, transform.rotation);
            Destroy(hit, 0.3f);
        }
        Destroy(gameObject);
    }
}
