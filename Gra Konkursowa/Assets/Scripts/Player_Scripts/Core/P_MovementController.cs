using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class P_MovementController : MonoBehaviour
{
    [Header("Movement variables")]
    public float P_MoveSpeed;
    public float arenaSpeed;
    public float hubSpeed;
    Vector2 inputMovement;
    bool canMove = true;
    [SerializeField]
    float moveSmoothnes;
    Vector2 currentInputVector;
    Vector2 smoothnesVector;

    [Header("Dash variables")]
    [SerializeField]
    private float P_dash_lenght;
    [SerializeField]
    private float P_dash_force;
    public float P_dash_cooldown;
    [SerializeField]
    private bool P_can_dash;

    Vector3 forward, right;
    private Camera mainCamera;

    [Header("Player rigidbody")]
    [SerializeField]
    Rigidbody P_rb;

    float set_P_MoveSpeed;

    [Header("Visual effects")]
    [SerializeField]
    TrailRenderer trail;
    bool walkingSFXPlayed = true;
    [SerializeField]
    VisualEffect dashEffect;
    [SerializeField]
    GameObject dashVFXObject;

    private Animator P_anim;

    [SerializeField] private GameObject playerWeapon;

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();

        set_P_MoveSpeed = P_MoveSpeed;
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        P_anim = GetComponentInChildren<Animator>();
        G_Controller.instatnce.inputs.Movement_Map.Dash.performed += _ => CheckDash();
    }

    private void FixedUpdate()
    {
        dashVFXObject.transform.position = transform.position;

        if (canMove) inputMovement = G_Controller.instatnce.inputs.Movement_Map.Movement.ReadValue<Vector2>();

        if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1.175f))
        {
            if (hit.collider.gameObject.layer == 7) Physics.gravity = new Vector3(0, -9.210280943f, 0);
            else Physics.gravity = new Vector3(0, -943.210280943f, 0);
        }
        else Physics.gravity = new Vector3(0, -943.210280943f, 0);

        Movement(inputMovement);
        NewPlayerAnimationSystem(inputMovement);
        ChangeMovementSet();
    }
    void ChangeMovementSet()
    {
        if (G_Controller.instatnce.gameStateManager.CurrentState == G_Controller.instatnce.gameStateManager.inTheHubState)
        {
            P_anim.SetBool("InHub", true);
            playerWeapon.SetActive(false);
        }
        else
        {
            playerWeapon.SetActive(true);
            P_anim.SetBool("InHub", false);
        }


    }
    void Movement(Vector2 inputs)
    {
        if (inputs.magnitude == 0)
        {
            P_rb.velocity = Vector3.zero;
            walkingSFXPlayed = false;
            WalkingAudio(false);
        }

        else
        {
            if (!walkingSFXPlayed)
            {
                WalkingAudio(true);
                walkingSFXPlayed = true;
            }
        }

        currentInputVector = Vector2.SmoothDamp(currentInputVector, inputs, ref smoothnesVector, moveSmoothnes);

        Vector3 moveVector = (right * currentInputVector.x) + (forward * currentInputVector.y);

        transform.LookAt(P_Direction);
        P_rb.AddForce(moveVector * P_MoveSpeed - P_rb.velocity, ForceMode.VelocityChange);

    }
    private void NewPlayerAnimationSystem(Vector2 input)
    {
        currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref smoothnesVector, moveSmoothnes);

        Vector3 inputVector = (right * currentInputVector.x) + (forward * currentInputVector.y);

        Vector3 animationVector = P_anim.gameObject.transform.InverseTransformDirection(inputVector);

        var VelocityX = animationVector.x;
        var VelocityZ = animationVector.z;

        this.P_anim.SetFloat("VelocityX", VelocityX);
        this.P_anim.SetFloat("VelocityY", VelocityZ);
    }

    public Vector3 P_Direction
    {
        get
        {
            Vector2 mousePosition = G_Controller.instatnce.inputs.Movement_Map.Player_Rotation.ReadValue<Vector2>();
            Ray cameraRay = mainCamera.ScreenPointToRay(mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLenght;

            if (groundPlane.Raycast(cameraRay, out rayLenght))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLenght);

                return new Vector3(pointToLook.x, transform.position.y, pointToLook.z);
            }
            else return Vector3.zero;
        }
    }

    void WalkingAudio(bool startOrPause)
    {
        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Player_Walking", startOrPause);
    }

    void CheckDash()
    {
        if (P_can_dash)
        {
            G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Player_Dash");
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        trail.emitting = true;

        dashEffect.SetVector3("Velocity", new Vector3(inputMovement.x, 0.0f, inputMovement.y));

        dashEffect.Play();

        float startTime = Time.time;

        P_can_dash = false;

        canMove = false;

        while (Time.time < startTime + P_dash_lenght)
        {
            P_MoveSpeed = P_dash_force;
            yield return null;
        }

        trail.emitting = false;
        P_MoveSpeed = set_P_MoveSpeed;

        inputMovement = new Vector2(0.0f, 0.0f);

        canMove = true;

        yield return new WaitForSeconds(P_dash_cooldown);

        P_can_dash = true;

        G_Controller.instatnce.AudioPlayer.PlayOrStopAudio("Dash_Regeneration");
    }
}