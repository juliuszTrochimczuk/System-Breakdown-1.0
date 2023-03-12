using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Opacity : MonoBehaviour
{
    private Coroutine opacity;

    [SerializeField]
    float speed = 0.35f;

    [SerializeField]
    float transparency = 0.55f;

    [Header("Materials")]
    [SerializeField]
    Material transparentMaterial;
    [SerializeField]
    Material opaqueMaterial;

    bool materialCondition;

    public void StartDiseapring(int opacityChange)
    {

        if (opacity != null) StopCoroutine(opacity);
        
        opacity = StartCoroutine(ColorChange(opacityChange));
    }

    IEnumerator ColorChange(int opacityChange)
    {
        Color wall_Color = gameObject.GetComponent<Renderer>().material.color;

        if (opacityChange == 1 && !materialCondition)
        {
            materialCondition = true;
            gameObject.GetComponent<Renderer>().material = transparentMaterial;
        }

        while (wall_Color.a > transparency && opacityChange == 1)
        {
            wall_Color.a -= opacityChange * speed * Time.deltaTime;
            gameObject.GetComponent<Renderer>().material.color = wall_Color;
            
            yield return new WaitForEndOfFrame();
        }
        
        while (wall_Color.a < 1f && opacityChange == -1)
        {
            wall_Color.a -= opacityChange * speed * Time.deltaTime;
            gameObject.GetComponent<Renderer>().material.color = wall_Color;
            
            yield return new WaitForEndOfFrame();
        }

        if (opacityChange == -1 && materialCondition)
        {
            materialCondition = false;
            gameObject.GetComponent<Renderer>().material = opaqueMaterial;
        }

        yield return null;
    }
}
