using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerV2 : MonoBehaviour
{
    #region Unity API

    private void Awake()
    {
        Cursor.visible = false;
        _cameraTransform = Camera.main.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        TransformController();
        CameraController();
    }

    protected void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }

    #endregion


    #region Main Methods

    private void TransformController()
    {
        Vector3 cameraForward = Vector3.Scale(_cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 direction = _moveInput.y * cameraForward + _moveInput.x * _cameraTransform.right;

        direction.Normalize();

        _rigidbody.velocity = direction * _moveSpeed;

        //transform.position += _moveSpeed * Time.deltaTime * direction;
    }

    private void CameraController()
    {
        Vector2 normalizedViewInput = _viewInput.normalized;

        transform.Rotate(0, normalizedViewInput.x * _viewSpeed, 0);

        if (_cameraTransform.localRotation.x < _lookUpMax)
        {
           Quaternion rotation = _cameraTransform.localRotation;
           float var = Mathf.Lerp(rotation.x, rotation.x + 0.01f, Time.time);
           _cameraTransform.localRotation = new Quaternion(var, rotation.y, rotation.z, rotation.w);
        }
        
        else if (_cameraTransform.localRotation.x > _lookUpMin)
        {
            Quaternion rotation = _cameraTransform.localRotation;
            float var = Mathf.Lerp(rotation.x, rotation.x - 0.01f, Time.time);
            _cameraTransform.localRotation = new Quaternion(var, rotation.y, rotation.z, rotation.w);
        }

        _cameraTransform.Rotate(-normalizedViewInput.y * _viewSpeed, 0, 0);
    }

    public void OnMoveInput(InputAction.CallbackContext ctx)
    {
        if (PauseMenu._isPaused) return;

        if (ctx.performed)
        {
            _moveInput = ctx.ReadValue<Vector2>();
        }

        if (ctx.canceled)
        {
            _moveInput = ctx.ReadValue<Vector2>();
        }
    }

    public void OnViewInput(InputAction.CallbackContext ctx)
    {
        if (PauseMenu._isPaused) return;

        _viewInput = ctx.ReadValue<Vector2>();
    }

    #endregion


    #region Private and Protected Members

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _viewSpeed;
    [SerializeField] private float _lookUpMin;
    [SerializeField] private float _lookUpMax;
    private Transform _cameraTransform;
    private Vector2 _moveInput;
    private Vector2 _viewInput;
    private Rigidbody _rigidbody;

	#endregion
}