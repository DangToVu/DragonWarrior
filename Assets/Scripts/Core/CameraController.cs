using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Room camera
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    // Follow player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // Room camera
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity, speed);

        // Follow player
        // Uncomment the following lines to enable camera follow feature.
         //transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
         //lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        // Update the camera's position based on the new room's position
        currentPosX = _newRoom.position.x;
        cam.farClipPlane = _newRoom.position.x + 500;
        cam.nearClipPlane = _newRoom.position.x - 1500;
    }

}
