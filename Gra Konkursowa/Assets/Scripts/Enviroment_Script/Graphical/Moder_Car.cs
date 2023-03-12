using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moder_Car : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    float delay;

    [SerializeField]
    [Range(0.0f, 2.0f)]
    float animationSpeed;

    private void Start()
    {
        StartCoroutine(animationParametrs());
    }

    IEnumerator animationParametrs()
    {
        yield return new WaitForSeconds(delay);

        animator.SetTrigger("Start_Hovering");

        animator.speed = animationSpeed;
    }
}
