using UnityEngine;

public class FPSPlayerController : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float lookSpeed = 2.0f;
    public GameObject projectilePrefab;
    public Transform shootPoint;
    private float rotationX = 0.0f;
    float horizontal, vertical;
    public Animator anim;
    private CharacterController characterController;
    public GameObject muzzleVFX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        characterController = GetComponent<CharacterController>();

        if (shootPoint == null)
        {
            shootPoint = Camera.main.transform;
        }
    }

    void Update()
    {
        HandlePlayerMovement();
        HandleMouseLook();
        HandleShooting();
    }

    void HandlePlayerMovement()
    {
        
         horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical).normalized;
        Vector3 moveVector = transform.TransformDirection(moveDirection) * walkSpeed;

        characterController.SimpleMove(moveVector);
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
    }

    void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && shootPoint != null)
        {
            Instantiate(muzzleVFX,shootPoint.position, shootPoint.rotation);
            Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}
