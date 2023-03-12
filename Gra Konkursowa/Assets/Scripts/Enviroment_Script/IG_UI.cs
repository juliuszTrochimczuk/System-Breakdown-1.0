using UnityEngine;
using UnityEngine.UI;

public class IG_UI : MonoBehaviour
{
    Transform itemTransform;

    [Header("UI")]
    [SerializeField]
    GameObject itemName;
    [SerializeField]
    Canvas canvas;

    private void Start()
    {
        itemTransform = gameObject.GetComponent<Transform>();
        canvas.worldCamera = G_Controller.instatnce.player.GetChild(1).GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 playerPos = G_Controller.instatnce.player.GetChild(0).position;

        if (Vector3.Distance(itemTransform.position, playerPos) <= 5f) Nearby(playerPos);
        else itemName.gameObject.SetActive(false);
    }

    void LateUpdate()
    {
        itemName.transform.LookAt(Camera.main.transform);
        itemName.transform.rotation = Quaternion.Euler(new Vector3(itemName.transform.rotation.eulerAngles.x + 30, itemName.transform.rotation.eulerAngles.y - 180, itemName.transform.rotation.eulerAngles.z));
    }

    private void Nearby(Vector3 playerPos) => itemName.SetActive(true);
}
