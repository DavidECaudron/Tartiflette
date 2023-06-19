using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private void Update()
    {
        float xRotation = _cameraInput.x * _speed;
        float yRotation = _cameraInput.y * _speed;
        transform.Rotate(xRotation, yRotation, 0);
    }

    public void OnRotateInput(InputAction.CallbackContext ctx)
    {
        _cameraInput = ctx.ReadValue<Vector2>();
    }

    [SerializeField] private float _speed;
    private Vector2 _cameraInput;
}
