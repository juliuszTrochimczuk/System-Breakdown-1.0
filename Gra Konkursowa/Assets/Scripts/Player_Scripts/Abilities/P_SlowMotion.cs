using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
using System.Threading.Tasks;

public class P_SlowMotion : Ability
{
    private List<EnemyInfo> enemies = new List<EnemyInfo>();

    private void OnEnable()
    {
        if (CheckingToActive(gameObject)) SlowMotion();
    }

    void SlowMotion()
    {
        enemies.Clear();

        foreach (EnemyWave enemyWave in Arena_Controller.Instance.Waves)
        {
            foreach (GameObject enemy in enemyWave.enemies)
            {
                if (enemy.GetComponentInChildren<H_Health>().HP > 0 && enemy != null)
                {
                    Animator animator = enemy.GetComponentInChildren<Animator>();
                    NavMeshAgent _agent = enemy.GetComponentInChildren<NavMeshAgent>();

                    enemies.Add(new EnemyInfo(_agent, animator));
                }
            }
        }

        ChangeingSpeed(0.5f);

        Timer();
    }

    private async void Timer()
    {
        await Task.Delay(3500);

        ChangeingSpeed(2);

        G_Controller.instatnce.PlayerSkills.RefreshingCooldown(abilityIndex);

        gameObject.SetActive(false);
    }

    void ChangeingSpeed(float multiplier)
    {
        int index = 0;
        List<int> indexList = new List<int>();

        foreach (EnemyInfo parametrs in enemies)
        {
            if (parametrs.agent.GetComponentInChildren<H_Health>().HP <= 0 || parametrs.agent == null)
            {
                indexList.Add(index);
            }
            index += 1;
        }
        for (int i = 0; i > indexList.Count; i++)
        {
            enemies.RemoveAt(indexList[i]);
        }

        foreach (EnemyInfo parametrs in enemies)
        {
            if (parametrs.agent is null && parametrs.animator is null) continue;
            parametrs.agent.speed *= multiplier;
            parametrs.animator.speed *= multiplier;
        }
    }
}

[System.Serializable]
public struct EnemyInfo
{
    public EnemyInfo(NavMeshAgent nav, Animator anim)
    {
        agent = nav;
        animator = anim;
    }

    public NavMeshAgent agent;
    public Animator animator;
}