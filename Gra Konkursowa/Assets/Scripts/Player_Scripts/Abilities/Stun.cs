using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Stun : MonoBehaviour
{
    [Header("Move speed variable")]
    public float moveSpeed;

    [Header("variables to explosion")]
    [HideInInspector]
    public float timerOfStun;
    [HideInInspector]
    bool exploded = false;
    [SerializeField]
    GameObject electrectityVFX;

    [Header("Enemy variables")]
    Animator animation;
    Hostile_AI stunned = null;
    NavMeshAgent agent;
    float speed;

    bool hitted;

    void Update()
    {
        if (!exploded)
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy_Bullet") || other.gameObject.name == "ConeVision") return;
        else if (!hitted)
        {
            exploded = true;
            hitted = true;

            electrectityVFX.SetActive(false);

            if (other.gameObject.CompareTag("Enemy"))
            {
                agent = other.gameObject.GetComponentInChildren<NavMeshAgent>();
                speed = agent.speed;
                ChangeSpeed(agent,0);
                animation = other.gameObject.GetComponentInChildren<Animator>();
                StopAnimation(animation, 0);
                StartCoroutine(StunAbility(other));
            }
        }
    }

    void StopAnimation(Animator enemyAnimation,float speed)
    {
        enemyAnimation.speed = speed;
    }

    void ChangeSpeed(NavMeshAgent enemy,float speed)
    {
        enemy.speed = speed;
    }

    IEnumerator StunAbility(Collider enemyCollision)
    {
        stunned = enemyCollision.gameObject.GetComponent<Hostile_AI>();
        stunned.Stun(true);

        H_Health enemyHealth = enemyCollision.gameObject.GetComponent<H_Health>();

        for (float i=0; i <= timerOfStun; i += Time.deltaTime)
        {
            if (enemyHealth.HP <= 0) break;
            else yield return new WaitForFixedUpdate();
        }

        stunned.Stun(false);

        StopAnimation(animation, 1);
        ChangeSpeed(agent, speed);

        yield return null;

        Destroy(gameObject);
    }
}
