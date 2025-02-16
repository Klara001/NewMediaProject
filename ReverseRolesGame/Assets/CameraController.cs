using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public bool useOffsetValues;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!useOffsetValues)
        {
            offset = target.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position - offset;

        targetPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);

        transform.position = targetPosition;

        transform.LookAt(target);
    }
}
