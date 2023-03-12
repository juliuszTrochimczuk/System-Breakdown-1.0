using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disco_Plates : MonoBehaviour
{
    [Header("Lists of colors")]
    [ColorUsage(true, true)]
    [SerializeField]
    Color[] colors;
    List<Color> randomList;

    [Header("Light object")]
    [SerializeField]
    Light discoLight;
    [SerializeField]
    bool isLight = true;

    [Header("Controlling Variables")]
    [SerializeField]
    MeshRenderer colorRenderer;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float lerpTime;
    float time;
    int colorIndex;

    void Update()
    {
        colorRenderer.material.color = Color.Lerp(colorRenderer.material.color, colors[colorIndex], lerpTime * Time.deltaTime * 15);

        if (isLight) discoLight.color = Color.Lerp(colorRenderer.material.color, colors[colorIndex], lerpTime * Time.deltaTime * 15);

        time = Mathf.Lerp(time, 1.0f, lerpTime * Time.deltaTime * 15);

        if (time > 0.9f)
        {
            time = 0;

            randomList = new List<Color>(colors);
            randomList.Remove(colors[colorIndex]);
            colorIndex = Random.Range(0, randomList.Count);
        }
    }
}
