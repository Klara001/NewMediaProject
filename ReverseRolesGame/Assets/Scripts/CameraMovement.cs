using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float yOffset = 1f;
    public float zOffset = -1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, yOffset, zOffset);
    }
}
