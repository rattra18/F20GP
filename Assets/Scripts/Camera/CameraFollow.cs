using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public float zPosition = -5f;
    public Vector3 offset;
    public Tilemap tilemap;

    void Start()
    {
        //Calculates based on the length of the tilemap and the aspect ratio of the device what size the camera should be for it to be consistent across many aspect ratios
        float  orthoSize = tilemap.cellBounds.size.x * Screen.height / Screen.width * 0.5f;
        Camera.main.orthographicSize = orthoSize;
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, target.position.y, zPosition);
        Vector3 intendedPosition = desiredPosition + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, intendedPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
