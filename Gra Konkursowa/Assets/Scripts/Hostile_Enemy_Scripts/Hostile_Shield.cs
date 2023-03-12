using UnityEngine;

public class Hostile_Shield : MonoBehaviour
{
    [Header("Main Hostile Position")]
    [SerializeField]
    Transform hostile;

    [Header("Speed of rotating")]
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float rotationSpeed;

    void Update()
    {
        gameObject.transform.position = new Vector3 (hostile.position.x, transform.position.y, hostile.position.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, hostile.rotation, Time.deltaTime);
    }
}
