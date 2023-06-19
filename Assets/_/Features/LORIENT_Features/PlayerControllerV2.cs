using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerV2 : MonoBehaviour
{
    #region Unity API

    //private void Awake()
    //{
    //    _cameraTransform = Camera.main.transform;
    //}

    private void Update()
    {
        TransformController();
        CameraController();
    }

    #endregion


    #region Main Methods

    private void TransformController()
    {
        Vector3 cameraForward = Vector3.Scale(_cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 direction = _moveInput.y * cameraForward + _moveInput.x * _cameraTransform.right;

        direction.Normalize();

        transform.TransformDirection(direction);

        transform.position += _moveSpeed * Time.deltaTime * direction;
    }

    private void CameraController()
    {
        Vector2 normalizedViewInput = _viewInput.normalized;

        transform.Rotate(0, normalizedViewInput.x * _viewSpeed, 0);

        if (_cameraTransform.localRotation.x < _lookUpMax)
        {
            Quaternion rotation = _cameraTransform.localRotation;
            _cameraTransform.localRotation = new Quaternion(rotation.x + 1f, rotation.y, rotation.z, rotation.w);
        }
        
        else if (_cameraTransform.localRotation.x > _lookUpMin)
        {
            Quaternion rotation = _cameraTransform.localRotation;
            _cameraTransform.localRotation = new Quaternion(rotation.x - 1f, rotation.y, rotation.z, rotation.w);
        }

        _cameraTransform.Rotate(-normalizedViewInput.y * _viewSpeed, 0, 0);
    }

    public void OnMoveInput(InputAction.CallbackContext ctx)
    {
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
        //if (_cameraTransform.rotation.x < _lookUpMax)
        //{
        //    Quaternion rotation = _cameraTransform.rotation;
        //    _cameraTransform.rotation = new Quaternion(rotation.x + 1f, rotation.y, rotation.z, rotation.w);
        //}
        //
        //else if (_cameraTransform.rotation.x > _lookUpMin)
        //{
        //    Quaternion rotation = _cameraTransform.rotation;
        //    _cameraTransform.rotation = new Quaternion(rotation.x - 1f, rotation.y, rotation.z, rotation.w);
        //}
        _viewInput = ctx.ReadValue<Vector2>();
    }

    #endregion


    #region Private and Protected Members

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _viewSpeed;
    [SerializeField] private float _lookUpMin;
    [SerializeField] private float _lookUpMax;
    [SerializeField] private Transform _cameraTransform;
    private Vector2 _moveInput;
    private Vector2 _viewInput;

	#endregion
}