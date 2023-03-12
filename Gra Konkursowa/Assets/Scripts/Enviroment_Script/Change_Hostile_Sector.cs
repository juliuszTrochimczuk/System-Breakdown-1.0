using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Hostile_Sector : MonoBehaviour
{
    Hostile_Sector map;

    bool playerEntered;

    private void Start()
    {
        map = FindObjectOfType<Hostile_Sector>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !playerEntered)
        {
            playerEntered = true;
            map.ChangingSector();
        }
    }
}
