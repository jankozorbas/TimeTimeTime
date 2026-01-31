using UnityEngine;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 2.5f;
    [SerializeField] private float acceleration = 6f;
    [SerializeField] private float gravity = -9.81f;

    private CharacterController characterController;
    private Vector3 velocity;
    private Vector3 currentMove;
    private float stamina;
    private bool isSprinting;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
        ApplyGravity();
    }

    private void HandleMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        Vector3 targetMove = transform.right * xInput + transform.forward * zInput;
        targetMove = Vector3.ClampMagnitude(targetMove, 1f);

        isSprinting = Input.GetKey(KeyCode.LeftShift) && stamina > 0f && zInput > 0f;

        float targetSpeed = walkSpeed;
        Vector3 targetVelocity = targetMove * targetSpeed;

        currentMove = Vector3.Lerp(currentMove, targetVelocity, acceleration * Time.deltaTime);

        characterController.Move(currentMove * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        if (characterController.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}