using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // The player
    public Vector3 offset = new Vector3(0, 5, -10);  // Position offset
    public float smoothSpeed = 0.125f;               // Smoothness

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        transform.position = smoothedPosition;

        transform.LookAt(target); // Optional: Makes the camera look at the player
    }
}
