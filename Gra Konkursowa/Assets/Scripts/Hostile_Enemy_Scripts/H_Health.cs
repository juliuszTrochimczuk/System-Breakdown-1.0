using UnityEngine;
using UnityEngine.UI;

public class H_Health : Health
{
    public float FancyHP { get; private set; }
    public Slider bar;

    void Awake()
    {
        HPanimSpeed = 1;
    }

    void Start()
    {
        HP = maxHP;
        FancyHP = 1;

        if (bar != null)
        {
            bar.minValue = 0;
            bar.maxValue = maxHP;
            bar.value = maxHP;
        }

        MainCam = GameObject.Find("Main Camera").transform;
    }
    
    void Update()
    {
        bar.value = HP;
    }

    void LateUpdate()
    {
        bar.transform.LookAt(bar.transform.position + MainCam.forward);
    }

}
