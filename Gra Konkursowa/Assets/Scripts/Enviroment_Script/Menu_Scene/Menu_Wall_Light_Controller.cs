using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Wall_Light_Controller : MonoBehaviour
{ 
    [SerializeField] private Light light;
  
    private float[] smoothing = new float[16];

    void Start()
    {
        for (int i = 0; i < smoothing.Length; i++)
        {
            smoothing[i] = .0f;
        }
    }

    void Update()
    {
        float sum = .0f;
     
        for (int i = 1; i < smoothing.Length; i++)
        {
            smoothing[i - 1] = smoothing[i];
            sum += smoothing[i - 1];
        }
   
        smoothing[smoothing.Length - 1] = Random.value;
        sum += smoothing[smoothing.Length - 1];

    
        light.intensity = sum / smoothing.Length;
    }
}
