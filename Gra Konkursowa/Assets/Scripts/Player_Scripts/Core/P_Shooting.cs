using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.VFX;

public class P_Shooting : MonoBehaviour
{
    [Header("Shooting statistics")]
    float range = 16.0f;
    [SerializeField]
    List<float> damageScale;
    public int baseDamage;
    [SerializeField]
    float distanceMultiplier;
    [SerializeField]
    float distance;

    [Header("Visual Effects")]
    [SerializeField]
    VisualEffect _psEnemy;
    [SerializeField]
    ParticleSystem _psObject;
    ParticleSystemRenderer _psObjectRenderer;
    [SerializeField]
    VisualEffect gunShotEffect;
    [SerializeField]
    Gradient[] gunShotGradients;

    [Header("Controling variables")]
    bool isShooting = false;
    bool isRealoding = false;
    float actualTime;
    int howManyAmmoLeft;
    int tierOfStatistics;
    [SerializeField]
    Transform bulletPoint;

    [Header("Visual Representation of ammo")]
    [SerializeField]
    TextMeshProUGUI ammoText;
    [SerializeField]
    TextMeshProUGUI maxAmmoText;

    [Header("Ammo for weapon")]
    private int ammo;
    public int maxAmmo;
    public int MaxAmmo
    {
        get
        {
            return maxAmmo;
        }

        set
        {
            ammo = value;
            ammoText.text = ammo.ToString();

            maxAmmo = value;
            maxAmmoText.text = maxAmmo.ToString();
        }
    }

    [Header("Timing variables")]
    [SerializeField]
    float rateOfFire;
    [SerializeField]
    float reloadingTime;

    [Header("Position to calculation the Raycast")]
    [SerializeField]
    Transform recoilPosition;

    [Header("Camera shaking")]
    [SerializeField]
    CinemachineVirtualCamera virutualCamera;
    CinemachineBasicMultiChannelPerlin perlin;
    [SerializeField]
    List<float> intensityLevels;
    [HideInInspector]
    public bool cameraShakingActive;

    [Header("Bullet trail")]
    [SerializeField]
    TrailRenderer bulletTrail;
    [SerializeField]
    Gradient[] bulletTrailGradients;

     [Header("Reload Popup")]
     [SerializeField]
     GameObject ReloadPopup;

    private void Awake()
    {
        perlin = virutualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        _psObjectRenderer = _psObject.GetComponent<ParticleSystemRenderer>();
    }

    private void Start()
    {
        G_Controller.instatnce.inputs.Combat_Map.Shooting.started += _ => Check(true);
        G_Controller.instatnce.inputs.Combat_Map.Shooting.canceled += _ => Check(false);
        G_Controller.instatnce.inputs.Combat_Map.Reload_Weapon.performed += _ => StartCoroutine(Reload());
    }

    private void Update()
    {
        if (ammo <= 5) ReloadPopup.SetActive(true);
        else ReloadPopup.SetActive(false);

        actualTime += Time.deltaTime;

        if (actualTime >= rateOfFire * 4)
        {
            tierOfStatistics = 0;
            howManyAmmoLeft = 0;
        }

        if (actualTime >= rateOfFire && ammo > 0 && isShooting && !isRealoding)
        {
            Vector3 player = G_Controller.instatnce.player.GetChild(0).transform.position;
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(player, fwd, out hit, 1f)) { }
            else
            {
                Shooting();
                actualTime = 0.0f;
            }
        }
        else if (ammo == 0 && G_Controller.instatnce.PlayerHealth.HP > 0 && !cameraShakingActive) perlin.m_AmplitudeGain = 0;
    }

    void Check(bool shooting)
    {
        isShooting = shooting;

        if (!shooting && !cameraShakingActive) perlin.m_AmplitudeGain = 0;
    }

    void ThrowingRaycast(int damage)
    {
        RaycastHit hit;

        TrailRenderer trail = Instantiate(bulletTrail, bulletPoint.position, Quaternion.identity);

        trail.colorGradient = bulletTrailGradients[tierOfStatistics];
        gunShotEffect.SetGradient("FlashGradient", gunShotGradients[tierOfStatistics]);

        gunShotEffect.Play();

        if (Physics.Raycast(bulletPoint.position, bulletPoint.forward, out hit, range))
        {
            Health target = hit.transform.GetComponent<Health>();

            StartCoroutine(SpawnTrail(trail, hit.point, 1));

            if (target != null && !target.gameObject.CompareTag("Player"))
            {
                if (Vector3.Distance(gameObject.transform.position, hit.transform.position) >= distance) target.HP -= (int)(damage * distanceMultiplier);
                else target.HP -= damage;

                if (target.gameObject.CompareTag("Enemy"))
                {
                    if (target.HP <= 0) G_Controller.instatnce.PlayerScore.GrantScore(ScoreChangingActions.KilledWithGun);
                    else
                    {
                        float pitch = Random.Range(0.8f, 1.2f);
                        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Hostile_Hit", pitch: pitch);
                    }
                    ShootParticleEffect(_psEnemy.gameObject, hit.point);
                }
                else if (target.gameObject.CompareTag("DestructableObject"))
                {
                    MeshRenderer hitRenderer = hit.transform.gameObject.GetComponent<MeshRenderer>();
                    if (hitRenderer != null) _psObjectRenderer.material = hitRenderer.material;
                    ShootParticleEffect(_psObject.gameObject, hit.point);
                }
            }
            else
            {
                MeshRenderer hitRenderer = hit.transform.gameObject.GetComponent<MeshRenderer>();
                if (hitRenderer != null) _psObjectRenderer.material = hitRenderer.material;
                ShootParticleEffect(_psObject.gameObject, hit.point);
            }
        }
        else
            StartCoroutine(SpawnTrail(trail, bulletPoint.position + bulletPoint.forward * 0xffff, 4095));
    }

    void ShootParticleEffect(GameObject particle, Vector3 point)
    {
        GameObject effect = Instantiate(particle, point, transform.rotation);
        Destroy(effect, 1);
    }

    IEnumerator SpawnTrail(TrailRenderer trail, Vector3 hit, int multiplier)
    {
        float time = 0;
        Vector3 startPos = trail.transform.position;
        while (time < 1)
        {
            if (trail != null)
            {
                trail.transform.position = Vector3.Lerp(startPos, hit, time);
                time += Time.deltaTime / (trail.time * multiplier);

                yield return new WaitForFixedUpdate();
            }
            else
                break;
        }

        if (trail != null)
            Destroy(trail.gameObject, 1);

        yield return null;
    }

    IEnumerator Reload()
    {
        if (ammo != maxAmmo && !isRealoding)
        {
            G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Rifle_Reloading");
            isRealoding = true;
            perlin.m_AmplitudeGain = 0;
            yield return new WaitForSeconds(reloadingTime);
            ammo = maxAmmo;
            ammoText.text = ammo.ToString();
            isRealoding = false;
            howManyAmmoLeft = 0;
            tierOfStatistics = 0;
        }
    }

    void Shooting()
    {
        ammo--;
        ammoText.text = ammo.ToString();

        howManyAmmoLeft++;

        if (howManyAmmoLeft > 1 && howManyAmmoLeft < 5)
            tierOfStatistics = 1;

        else if (howManyAmmoLeft >= 5)
            tierOfStatistics = 2;

        ThrowingRaycast((int)(baseDamage * damageScale[tierOfStatistics]));

        if (!cameraShakingActive) perlin.m_AmplitudeGain = intensityLevels[tierOfStatistics];

        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Rifle_Shooting");
    }

    public void AmmoChanging(int newValue)
    {
        MaxAmmo = newValue;
    }
}
