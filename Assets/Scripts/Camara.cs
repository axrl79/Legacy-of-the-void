using UnityEngine;

public class Camara : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothSpeed = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
}