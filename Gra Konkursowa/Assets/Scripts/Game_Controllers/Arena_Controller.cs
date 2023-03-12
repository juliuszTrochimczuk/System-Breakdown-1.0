using System;
using System.Collections.Generic;
using UnityEngine;

public class Arena_Controller : MonoBehaviour
{
    [Header("List of enemies")]
    public List<DifficultyWaveSet> difficultyWaveSets;
    public List<EnemyWave> Waves
    {
        get
        {
            if (difficultyWaveSets.Count == 0) return new List<EnemyWave>();
            return difficultyWaveSets[G_Controller.instatnce.difficulty - 1].enemyWaveSet;
        }
    }
    int howManyEnemies;

    [Header("Door to arena")]
    [SerializeField]
    List<GameObject> doorToNextLevel;

    [Header("Waves info")]
    [SerializeField]
    private bool horde;
    private int _wave;
    public int Wave
    {
        get
        {
            return _wave;
        }
        set
        {
            if (value > Waves.Count - 1) throw new IndexOutOfRangeException();
            _wave = value;
            foreach (GameObject enemy in Waves[_wave].enemies)
            {
                Health enemyHealth = enemy.GetComponentInChildren<Health>();
                enemyHealth.maxHP = (int)(enemyHealth.maxHP * (1 + (G_Controller.instatnce.difficultyHPMultiplier * (G_Controller.instatnce.difficulty - 1))));
                enemyHealth.HP = enemyHealth.maxHP;

                Hostile_AI hostile_AI = enemy.GetComponentInChildren<Hostile_AI>();

                hostile_AI.damage = (int)(hostile_AI.damage * (1 + (G_Controller.instatnce.difficultyDamageMultiplier * (G_Controller.instatnce.difficulty - 1))));
                hostile_AI.experienceGive = (int)(hostile_AI.experienceGive * (1 + (G_Controller.instatnce.difficultyXPMultiplier * (G_Controller.instatnce.difficulty - 1))));
                hostile_AI.moneyGive = (int)(hostile_AI.moneyGive * (1 + (G_Controller.instatnce.difficultyMoneyMultiplier * (G_Controller.instatnce.difficulty - 1))));

                enemy.SetActive(true);
            }
        }
    }

    public static Arena_Controller Instance { get; private set; }

    [Header("Syringe controll")]
    Vector3 killedEnemyPosition;

    bool arenaCleared = false;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        if (Waves.Count == 0) return;
        if (!horde)
        {
            Wave = UnityEngine.Random.Range(0, Waves.Count);
            howManyEnemies = Waves[Wave].enemies.Count;
        }
        else
        {
            Wave = 0;
            for (int i = 0; i < Waves.Count; i++)
            {
                for (int enemyIndex = 0; enemyIndex < Waves[i].enemies.Count; enemyIndex++) howManyEnemies++;
            }
        }

        foreach (GameObject doorElement in doorToNextLevel) doorElement.SetActive(false);

        foreach (GameObject enemy in Waves[Wave].enemies) enemy.SetActive(true);

        G_Controller.instatnce.UIController.enemyCounter.text = howManyEnemies.ToString();
    }

    void Update()
    {
        if (Waves.Count == 0) return;

        foreach (GameObject enemy in Waves[Wave].enemies)
        {
            try
            {
                killedEnemyPosition = enemy.transform.GetChild(0).position;
            }
            catch { }

            if (enemy == null)
            {
                Waves[Wave].enemies.Remove(enemy);
                howManyEnemies--;

                if (howManyEnemies == 1) Waves[Wave].enemies[0].GetComponentInChildren<Hostile_AI>().sightRange *= 1000f;

                G_Controller.instatnce.UIController.enemyCounter.text = howManyEnemies.ToString();
                break;
            }
        }
        if (Waves[Wave].enemies.Count == 0)
        {
            if (horde)
            {
                if (Wave == Waves.Count - 1)
                {
                    ArenaCleared();
                }
                else Wave++;
            }
            else
            {
                ArenaCleared();
            }
        }
    }

    void ArenaCleared()
    {
        if (!arenaCleared)
        {
            foreach (GameObject doorElement in doorToNextLevel) doorElement.SetActive(true);

            G_Controller.instatnce.UIController.doorPopup.SetActive(true);
            G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Arena_Cleared");
            foreach (GameObject enemy in Waves[Wave].enemies) enemy.SetActive(true);
            SpawnSyringe(killedEnemyPosition);
        }
    }

    void SpawnSyringe(Vector3 spawnPosition)
    {
        Instantiate(G_Controller.instatnce.syringe, spawnPosition, Quaternion.identity);
        arenaCleared = true;
    }
}

[Serializable]
public class EnemyWave
{
    public List<GameObject> enemies;
}

[Serializable]
public class DifficultyWaveSet
{
    public List<EnemyWave> enemyWaveSet;
}
