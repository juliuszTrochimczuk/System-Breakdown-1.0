using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp_Objects : MonoBehaviour
{
    [Header("It need to light")]
    [SerializeField]
    bool isLampOn;
    [SerializeField]
    List<GameObject> lampLights;

    void Awake()
    {
        if (isLampOn)
            LightState(true);
        else LightState(false);
    }

    void LightState(bool state)
    {
        foreach(GameObject light in lampLights)
        {
            light.SetActive(state);
        }
    }
}
