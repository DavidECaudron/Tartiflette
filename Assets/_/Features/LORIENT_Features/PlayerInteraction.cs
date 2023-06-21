using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Debug.DrawRay(_camera.transform.position, _camera.transform.forward * _range, Color.red);
    }

    private void FixedUpdate()
    {
        if (objectRigidbody)
        {
            Vector3 directionPoint = _pickUpTarget.position - objectRigidbody.position;
            float distanceToPoint = directionPoint.magnitude;

            objectRigidbody.velocity = directionPoint * 12f * distanceToPoint;
        }
    }

    public void OnMouseInput(InputAction.CallbackContext context)
    {
        if (context.started && !_isInputDown)
        {
            CheckIfTargetIsBed();
            CheckIfTagetIsDoor();
            ObjectAction();
            _isInputDown = true;
        }
        
        else if (context.canceled && _isInputDown)
        {
            ObjectAction();
            _isInputDown = false;
        }
    }

    private void CheckIfTargetIsBed()
    {
        if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _range, _layerMask)) return;

        if (hit.collider.CompareTag("Bed"))
        {
            Debug.Log("zzz");
            PauseMenu.QuitGame();
        }
    }

    private void CheckIfTagetIsDoor()
    {
        if (!Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _range, _layerMask)) return;

        if (hit.collider.CompareTag("Door"))
        {
            hit.collider.GetComponent<DoorAnimator>().ToggleDoor();
        }
    }

    public void ObjectAction()
    {
        if (objectRigidbody)
        {
            objectRigidbody.useGravity = true;
            objectRigidbody = null;
            return;
        }

        Ray cameraRay = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(cameraRay, out RaycastHit hit, _pickUpRange, _layerMask))
        {
            objectRigidbody = hit.rigidbody;
            objectRigidbody.useGravity = false;
        }
        else return;
    }


    private bool _isCarryingPickableObject;
    private Camera _camera;
    private bool _isInputDown;
    private Rigidbody objectRigidbody;

    [SerializeField] private float _pickUpRange;
    [SerializeField] private Transform _pickUpTarget;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _range;
}
