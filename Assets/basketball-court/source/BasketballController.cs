using UnityEngine;

public class BasketballController : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 5f;
    public Transform cam;
    public float cameraDistance = 6f;
    public float cameraHeight = 3f;
    public float mouseSensitivity = 3f;

    private Rigidbody rb;
    private bool rotatingCamera = false;
    private float yaw = 0f;
    private float pitch = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (cam == null) cam = Camera.main.transform;
    }

    void Update()
    {
        // jump
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // rclick
        if (Input.GetMouseButtonDown(1))
        {
            rotatingCamera = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetMouseButtonUp(1))
        {
            rotatingCamera = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // crotation
        if (rotatingCamera)
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
            pitch = Mathf.Clamp(pitch, -10f, 60f);
        }
    }

    void FixedUpdate()
    {
        // camera relative rotation controlling movement
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = cam.forward;
        Vector3 right = cam.right;

        forward.y = 0; 
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 move = (forward * v + right * h).normalized;

        rb.AddForce(move * moveForce, ForceMode.Force);
    }

    void LateUpdate()
    {
        // camera follow
        
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0);
        cam.position = transform.position - rot * Vector3.forward * cameraDistance + Vector3.up * cameraHeight;
        cam.LookAt(transform.position + Vector3.up * 1f);
    }
}