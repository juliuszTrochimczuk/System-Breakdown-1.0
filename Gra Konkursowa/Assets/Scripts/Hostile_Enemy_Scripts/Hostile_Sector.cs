using System.Collections.Generic;
using UnityEngine;

public class Hostile_Sector : MonoBehaviour
{
    [Header("Hostiles on Map")]
    [SerializeField]
    List<SectorsOnMap> sectorsInDifficulty;
    List<GameObject> enemies;

    int whichSectorIsActive = 0;

    private void Start()
    {
        enemies = new List<GameObject>(Arena_Controller.Instance.Waves[Arena_Controller.Instance.Wave].enemies);

        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponentInChildren<Hostile_AI>().enabled = false;
        }

        ActivatingSector();
    }

    public void ChangingSector()
    {
        whichSectorIsActive++;
        ActivatingSector();
    }

    void ActivatingSector()
    {
        List<GameObject> activeEnemies = new List<GameObject>(enemies);

        for (int i = 0; i < sectorsInDifficulty[G_Controller.instatnce.difficulty - 1].sectorsOnWave[Arena_Controller.Instance.Wave].sector[whichSectorIsActive]; i++)
        {
            Hostile_AI hostile = activeEnemies[i].GetComponentInChildren<Hostile_AI>();
            hostile.enabled = true;
            enemies.Remove(hostile.transform.parent.gameObject);
        }
    }
}

[System.Serializable]
public class SectorsOnMap
{
    public List<SectorsOnWave> sectorsOnWave;
}

[System.Serializable]
public class SectorsOnWave
{
    public List<int> sector;
}