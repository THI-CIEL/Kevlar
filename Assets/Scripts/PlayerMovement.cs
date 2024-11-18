using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 400f;
    [SerializeField]private float sprintSpeed = 600f;
    [SerializeField]private Rigidbody rb;
    [SerializeField]private Transform orientation;

    private float moveX, moveZ;
    private Vector3 moveDirection;
    public void onMoveInput(InputAction.CallbackContext context)
    {
        moveX = context.ReadValue<Vector2>().x;
        moveZ = context.ReadValue<Vector2>().y;
    }
    void FixedUpdate()
    {
        moveDirection = orientation.forward * moveX + orientation.right * moveZ;
        rb.AddForce(moveDirection * speed * Time.deltaTime);
    }
}
