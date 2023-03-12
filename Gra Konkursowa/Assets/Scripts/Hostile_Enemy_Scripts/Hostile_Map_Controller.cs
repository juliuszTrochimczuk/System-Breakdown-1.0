using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hostile_Map_Controller : MonoBehaviour
{
    Arena_Controller arenaController;
    public List<GameObject> enemiesOnMap;
    public List<GameObject> enemiesIsHostile;
    private bool listCheck;
    private void Awake()
    {
        arenaController = GetComponent<Arena_Controller>();

    }
    private void Start()
    {

    }
    private void Update()
    {
        if (!listCheck)
        {
            StartCoroutine(listUpdate());
        }
    }
    IEnumerator listUpdate()
    {
        listCheck = true;
        foreach (GameObject enemy in enemiesOnMap.ToArray())
        {
            if (!enemiesIsHostile.Contains(enemy))
            {
                if (enemy.GetComponentInChildren<Melee_Hostile_AI_Controller>() != null)
                {
                    if (enemy.GetComponentInChildren<Melee_Hostile_AI_Controller>().isChasing)
                    {
                        enemiesIsHostile.Add(enemy);
                    }
                }
                else if (enemy.GetComponentInChildren<Ranged_Hostile_AI_Controller>() != null)
                {
                    if (enemy.GetComponentInChildren<Ranged_Hostile_AI_Controller>().isChasing)
                    {
                        enemiesIsHostile.Add(enemy);
                    }
                }
            }
        }
        foreach (GameObject obj in enemiesIsHostile.ToArray())
        {
            if (obj == null)
            {
                enemiesIsHostile.Remove(obj);
            }
        }
        enemiesOnMap = arenaController.Waves[arenaController.Wave].enemies;
        yield return new WaitForSeconds(1f);
        listCheck = false;
    }
}
