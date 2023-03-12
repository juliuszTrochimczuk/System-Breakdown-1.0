using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Sight_Script : MonoBehaviour
{

    private LineRenderer lr;
    [SerializeField]
    private Transform EndPoint;

    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);

        RaycastHit Laser_Hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out Laser_Hit, 20))
        {
            lr.SetPosition(1, Laser_Hit.point);
        }
        else
        {
            lr.SetPosition(1, EndPoint.position);
        }

    }
}
