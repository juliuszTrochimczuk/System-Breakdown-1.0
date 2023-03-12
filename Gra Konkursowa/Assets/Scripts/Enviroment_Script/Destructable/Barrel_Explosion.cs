using System.Collections;
using UnityEngine;
using Cinemachine;

public class Barrel_Explosion : MonoBehaviour
{
    [Header("Mesh")]
    [SerializeField]
    MeshRenderer barrelMeshRenderer;
    [SerializeField]
    MeshCollider barrelMeshCollider;

    [Header("Visual Effect")]
    [SerializeField]
    GameObject explosionEffect;
    [SerializeField]
    GameObject fireEffect;

    [Header("Damage")]
    [SerializeField]
    int damage;
    Health hitted;

    [Header("Camera Shaking Intensity")]
    [SerializeField]
    float intensity = 5f;

    public void DamagedBarrel()
    {
        fireEffect.SetActive(true);
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Barrel_Hurts");
    }

    public void Explosion()
    {
        barrelMeshRenderer.enabled = false;
        barrelMeshCollider.enabled = false;

        Collider[] hits = Physics.OverlapSphere(transform.position, 3f);

        foreach (Collider hit in hits)
        {
            if (hit.gameObject.CompareTag("Player") || hit.gameObject.CompareTag("Enemy") || hit.gameObject.CompareTag("DestructableObject"))
            {
                hitted = hit.gameObject.GetComponent<Health>();
                hitted.HP -= damage;

                if (hit.gameObject.CompareTag("Enemy") && hitted.HP <= 0)
                    G_Controller.instatnce.PlayerScore.GrantScore(ScoreChangingActions.KilledByBarrel);
            }
        }

        explosionEffect.SetActive(true);
        fireEffect.SetActive(false);

        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Barrel_Explosion");

        StartCoroutine(cameraShaking());
    }

    IEnumerator cameraShaking()
    {
        CinemachineVirtualCamera virtualCamera = G_Controller.instatnce.player.GetChild(2).gameObject.GetComponent<CinemachineVirtualCamera>();
        CinemachineBasicMultiChannelPerlin perlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        G_Controller.instatnce.PlayerShooting.cameraShakingActive = true;

        perlin.m_AmplitudeGain = intensity;
        
        yield return new WaitForSeconds(0.3f);

        perlin.m_AmplitudeGain = 0f;

        G_Controller.instatnce.PlayerShooting.cameraShakingActive = false;
    }
}
