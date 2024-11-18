using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]private float mouseX, mouseY, rotationX, rotationY;
    [SerializeField]private Transform orientation;
    public void onMouseInput(InputAction.CallbackContext context)
    {
        mouseX = context.ReadValue<Vector2>().x;
        mouseY = context.ReadValue<Vector2>().y;
    }

    void Update()
    {
        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY + 90f, 0);
    }
}
