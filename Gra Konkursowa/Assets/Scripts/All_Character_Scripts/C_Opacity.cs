using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class C_Opacity : MonoBehaviour
{
    [HideInInspector]
    public int change;
    List<GameObject> last_walls = new List<GameObject>();
    List<GameObject> temporary_list;
    private Vector3 oldposition;
    
    [SerializeField]
    private Transform objectToFollow;

    private void Awake()
    {
        oldposition = transform.position;
    }
    
    void Update()
    {
        Vector3 objectPos = new Vector3(objectToFollow.position.x, 0, objectToFollow.position.z);
        

        transform.position = objectPos + oldposition;

        List<RaycastHit> walls;
        float distance = Vector3.Distance(transform.position, G_Controller.instatnce.player.GetChild(0).position) - 1;
        walls = Physics.RaycastAll(transform.position, transform.forward, distance).ToList();

        for (int i = walls.Count - 1; i >= 0; i--)
        {
            if (!last_walls.Contains(walls[i].transform.gameObject) && (walls[i].transform.CompareTag("Obstacle")))
            {
                last_walls.Add(walls[i].transform.gameObject);
                change = 1;
                walls[i].collider.GetComponent<Object_Opacity>().StartDiseapring(change);
            }
        }

        temporary_list = new List<GameObject>();

        foreach (RaycastHit hit in walls) temporary_list.Add(hit.transform.gameObject);

        List<GameObject> temporary = new List<GameObject>();

        foreach (GameObject transparent in last_walls)
        {
            if (!temporary_list.Contains(transparent))
            {
                change = -1;

                if (transparent != null)
                {
                    Object_Opacity object_opacity = transparent.GetComponent<Object_Opacity>();

                    if (object_opacity != null)
                    {
                        object_opacity.StartDiseapring(change);
                        temporary.Add(transparent);
                    }
                }
            }
        }

        foreach (GameObject temp in temporary) last_walls.Remove(temp);
    }
}