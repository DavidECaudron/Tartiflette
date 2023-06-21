using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        Debug.DrawRay(_cameraTransform.position, _cameraTransform.forward * _range, Color.red);

        //else if (hit.collider.CompareTag(""))
        //{
            //if (!_isInputDown) return;
        //}

        //else if (hit.collider.CompareTag(""))
        //{
            //if (!_isInputDown) return;
        //}
    }

    public void OnMouseInput(InputAction.CallbackContext context)
    {
        if (context.started && !_isInputDown)
        {
            CheckIfTargetIsBed();
            CheckIfTagetIsDoor();
            //CheckIfTargetIsPickableObject();
            _isInputDown = true;
        }
        
        else if (context.canceled && _isInputDown)
        {
            _isInputDown = false;
        }
    }

    private void CheckIfTargetIsBed()
    {
        if (!Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit, _range, _layerMask)) return;

        if (hit.collider.CompareTag("Bed"))
        {
            Debug.Log("zzz");
            PauseMenu.QuitGame();
        }
    }

    private void CheckIfTagetIsDoor()
    {
        if (!Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit, _range, _layerMask)) return;

        if (hit.collider.CompareTag("Door"))
        {
            hit.collider.GetComponent<DoorBehaviour>().DoorInteraction();
        }
    }

    private void CheckIfTargetIsPickableObject()
    {
        if (!Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit, _range, _layerMask)) return;

        if (hit.collider.CompareTag("ObjectA"))
        {
            hit.transform.SetParent(_playerTransform);
            _isCarryingPickableObject = true;
        }

        else if (hit.collider.CompareTag("ObjectB"))
        {
            hit.transform.SetParent(_playerTransform);
            _isCarryingPickableObject = true;
        }

        else if (hit.collider.CompareTag("ObjectC"))
        {
            hit.transform.SetParent(_playerTransform);
            _isCarryingPickableObject = true;
        }
    }

    public static bool _isCarryingPickableObject;

    private Transform _cameraTransform;
    private Transform _playerTransform;
    private bool _isInputDown;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private float _range;
}
