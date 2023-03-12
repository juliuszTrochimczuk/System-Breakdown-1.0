using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Free_Camera : MonoBehaviour
{
    [SerializeField]
    GameObject OldCamera;
    [SerializeField]
    GameObject freeCamera;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotationSpeed;
    bool activation;
    float playerSpeed;

    private void Start()
    {
        G_Controller.instatnce.inputs.Other_Map.Free_Camera.performed += _ => CameraActivation();
        G_Controller.instatnce.inputs.Movement_Map.Dash.performed += _ => ChangingCameraSpeed();
    }

    private void Update()
    {
        Vector2 cameraMove = G_Controller.instatnce.inputs.Movement_Map.Movement.ReadValue<Vector2>();
        freeCamera.transform.Translate(new Vector3(cameraMove.x, 0.0f, cameraMove.y) * moveSpeed * Time.deltaTime);

        Vector2 cameraRotation = G_Controller.instatnce.inputs.Movement_Map.Player_Rotation.ReadValue<Vector2>();
        freeCamera.transform.rotation = Quaternion.Euler(new Vector3 (-cameraRotation.y, cameraRotation.x) / rotationSpeed);

        if (activation) G_Controller.instatnce.PlayerMovement.P_MoveSpeed = 0;
    }

    void CameraActivation()
    {
        if (!activation)
        {
            OldCamera.SetActive(false);
            freeCamera.SetActive(true);

            activation = true;

            playerSpeed = G_Controller.instatnce.PlayerMovement.P_MoveSpeed;

            G_Controller.instatnce.UIController.gameObject.SetActive(false);

            Cursor.visible = false;
        }
        else
        {
            OldCamera.SetActive(true);
            freeCamera.SetActive(false);

            activation = false;

            G_Controller.instatnce.PlayerMovement.P_MoveSpeed = playerSpeed;

            G_Controller.instatnce.UIController.gameObject.SetActive(true);

            Cursor.visible = true;
        }
    }

    void ChangingCameraSpeed()
    {
        if (moveSpeed == 10) moveSpeed /= 2;
        else if (moveSpeed == 5) moveSpeed *= 2;
    }
}
