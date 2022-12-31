using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.04f;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        transform.position = newPosition;
    }
}
