using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    private CharacterController controller;
    private Vector3 moveDir;
    public bool canMove = true;


    void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (!canMove) return; // Don't do anything if player is locked

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        moveDir = transform.right * h + transform.forward * v;
        controller.Move(moveDir * moveSpeed * Time.deltaTime);
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);

    }
}
