using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 threshholdDistance;
    void Start()
    {

    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + threshholdDistance;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
