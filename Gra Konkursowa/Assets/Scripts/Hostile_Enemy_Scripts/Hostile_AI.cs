using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hostile_AI : MonoBehaviour
{
    protected NavMeshAgent agent;

    private Animator animator;
    private Health enemy_target_controller;

    [SerializeField]
    protected GameObject player;

    [SerializeField]
    public LayerMask whatIsPlayer;

    [Header("Player Interactions Range")]
    public float sightRange;
    public float attackRange;

    [Header("Attack")]
    [SerializeField]
    bool alreadyAttacked;
    public float timeBetweenAttacks;
    public int damage;

    [SerializeField]
    private float attackDelay;

    public Transform beginingPos;

    private bool beginingCondition = false;

    [Header("Enemy States")]
    public bool isAttacked;
    public bool isStuned;
    public bool isChasing;


    [Header("Enemy death gain to Player")]
    public int moneyGive;
    public int experienceGive;

    [Header("Enemy parts that will change color under stun")]
    [SerializeField]
    List<SkinnedMeshRenderer> partsRenderer;
    [SerializeField]
    Material systemError;
    [SerializeField]
    Material systemOn;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        enemy_target_controller = GetComponent<H_Health>();

        if (beginingPos == null) beginingCondition = true;
    }

    protected void ActivateAI()
    {
        if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.loadingSceneState || G_Controller.instatnce.PlayerHealth.HP <= 0 || G_Controller.instatnce.levelLoader.alpha > 0) return;
        if (isStuned) return;
        if (enemy_target_controller.HP > 0f)
        {
            if (playerInAttackRange()) Attack();
            else if (alreadyAttacked)
            {
                agent.SetDestination(transform.position);
                
            }
            else if ((playerInDetectionRange() && !alreadyAttacked || isAttacked))
            {
                Chase();
                isChasing = true;
            }

        }

        else
        {
            agent.SetDestination(transform.position);
            animator.SetBool("IsAlive", false);
        }
    }

    public void Stun(bool state)
    {
        isStuned = state;
        foreach(SkinnedMeshRenderer renderer in partsRenderer)
        {
            if (state) renderer.material = systemError;
            else renderer.material = systemOn;
        }
    }

    private bool playerInDetectionRange()
    {
        return Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
    }
    private bool playerInAttackRange()
    {
        if (Physics.Raycast(transform.position, (G_Controller.instatnce.playersModelTransform.position - transform.position).normalized, out RaycastHit hit, Mathf.Infinity) && hit.collider.CompareTag("Player"))
        {
            return Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        }
        return false;
    }

    private void Chase()
    {
        animator.SetBool("IsChasing", true);
        agent.SetDestination(player.transform.position);
    }

    private void Attack()
    {
        transform.LookAt(player.transform);
        agent.SetDestination(transform.position);

        if (!alreadyAttacked)
        {
            animator.SetBool("IsChasing", false);
            animator.SetTrigger("Attack");
            Invoke(nameof(TypeOfAttack), attackDelay);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }
    }

    protected virtual void TypeOfAttack()
    {

    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void DamagedByPlayer()
    {
        G_Controller.instatnce.PlayerScore.GrantScore(ScoreChangingActions.AttackingEnemy);

        isAttacked = true;

        Collider[] enemiesCollider = Physics.OverlapSphere(gameObject.transform.position, 10);

        foreach (Collider enemyObject in enemiesCollider)
        {
            if (enemyObject.gameObject.CompareTag("Enemy"))
                enemyObject.gameObject.GetComponent<Hostile_AI>().isAttacked = true;
        }
    }

    public void EnemyDeath()
    {
        G_Controller.instatnce.PlayerMoney.Scrap += moneyGive;
        G_Controller.instatnce.PlayerMoney.scrapEarned += moneyGive;
        G_Controller.instatnce.PlayerExperience.XP += experienceGive;

        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Hostile_Died");
    }
}

