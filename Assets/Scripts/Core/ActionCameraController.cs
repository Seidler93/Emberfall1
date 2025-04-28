using UnityEngine;

public class ActionCameraController : MonoBehaviour
{
    public Transform player;
    // public Transform cameraRig;
    public Transform lookPivot;

    public float mouseSensitivity = 100f;
    public float verticalRotationLimit = 80f;

    private float xRotation = 0f;

    public bool canMove = true;

    void Update()
    {
        if (!canMove) return;
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate player left/right
        // player.Rotate(Vector3.up * mouseX);

        // Tilt look pivot up/down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalRotationLimit, verticalRotationLimit);

        lookPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }


}
