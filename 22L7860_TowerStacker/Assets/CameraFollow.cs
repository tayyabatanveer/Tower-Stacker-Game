using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The target the camera will follow 
    public float smoothSpeed = 0.125f;  // The speed 
    public Vector3 offset;  // The offset from the target 

    void FixedUpdate()
    {
        if (target != null)
        {
            
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
