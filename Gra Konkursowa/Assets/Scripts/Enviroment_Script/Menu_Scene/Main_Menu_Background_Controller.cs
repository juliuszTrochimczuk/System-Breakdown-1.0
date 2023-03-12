using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Background_Controller : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z >= 18)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -9);
        }
    }
}
