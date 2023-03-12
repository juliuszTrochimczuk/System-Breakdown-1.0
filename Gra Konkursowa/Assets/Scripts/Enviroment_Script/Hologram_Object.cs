using System.Collections.Generic;
using UnityEngine;

public class Hologram_Object : MonoBehaviour
{
    [Header("Hologramic object")]
    [SerializeField]
    GameObject hologram;
    [SerializeField]
    List<MeshRenderer> hologramMesh;
    [SerializeField]
    float speedOfHologram;

    [Header("Light of Hologram")]
    [SerializeField]
    Light hologramLight;

    [Header("Colors to hologram")]
    [SerializeField]
    Color baseHologramColor;
    [SerializeField]
    [ColorUsage(true, true)]
    Color emissionColor;

    void Start()
    {
        foreach (MeshRenderer mesh in hologramMesh)
        {
            mesh.material.SetColor("Base_Color", baseHologramColor);
            mesh.material.SetColor("Emission_Color", emissionColor);
        }

        hologramLight.color = baseHologramColor;
    }

    void Update()
    {
        hologram.transform.Rotate(new Vector3(0.0f, speedOfHologram * Time.deltaTime, 0.0f));
    }
}
