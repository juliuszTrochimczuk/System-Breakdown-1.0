using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public enum HPchangingActions { DamagedByBullet, DamagedByRocket, DamageToPlayer}

    public UnityEvent deathActions;
    public UnityEvent onDamage;

    public bool invincible = false;

    public bool IsAlive { get; private set; }

    [SerializeField]
    public int maxHP;

    public int HP
    {
        get
        {
            return _hp;
        }
        set
        {
            if (invincible) return;
            if (HP > value)
            {
                onDamage.Invoke();
            }
            if (value > 0) IsAlive = true;
            _hp = value;
            if (!AllowOverheal && value > maxHP) _hp = maxHP;
            if (_hp <= 0 && IsAlive)
            {
                deathActions.Invoke();
                IsAlive = false;
            }
        }
    }

    private void Awake()
    {
        IsAlive = true;
    }

    [SerializeField]
    private int _hp;
    public bool AllowOverheal { get; set; }
    public float HPanimSpeed { get; set; }
    public float medkitHealing = 0.2f;
    public Transform MainCam { get; set; }

    public void ChangeHP(HPchangingActions action)
    {
        switch (action)
        {
            case HPchangingActions.DamagedByBullet:
                HP -= 20;
                break;
            case HPchangingActions.DamagedByRocket:
                HP -= 25;
                break;

            case HPchangingActions.DamageToPlayer:
                HP -= 10;
                break;
        }
    }
}