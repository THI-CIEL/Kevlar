using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Définition des variables par défaut
    //Variables de vitesse Marche et Sprint / Puissance du saut
    [SerializeField] private float speed = 400f;
    [SerializeField] private float sprintSpeed = 600f;
    [SerializeField] private float jumpForce = 6f;
    //
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform orientation;
    
    //Définitions des variables pratiques
    //
    private float moveX, moveZ;
    private Vector3 moveDirection;
    //
    private bool grounded = false;
    private int nbSaut = 1;
    private bool running = false;
    
    public void onSprintInput(InputAction.CallbackContext context)
    {
        running = context.performed;
    }
    public void onMoveInput(InputAction.CallbackContext context)
    {
        moveX = context.ReadValue<Vector2>().x;
        moveZ = context.ReadValue<Vector2>().y;
    }

    public void onJumpInput(InputAction.CallbackContext context)
    {
        if (context.performed && nbSaut > 0)
        {
            jump();
            nbSaut --;
        }
    }
    private void jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        moveDirection = orientation.forward * moveX + orientation.right * moveZ;
        moveDirection *= running ? sprintSpeed : speed;
        rb.AddForce(moveDirection * Time.deltaTime);
    }
    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            grounded = true;
            nbSaut = 1;
        }
        else
        {
            grounded = false;
        }
    }
}