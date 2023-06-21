using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{

    public Transform m_pivot;
    private void Awake()
    {
        _doorTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        DoorInteraction();
    }

    public void DoorInteraction()
    {
        if (_isRotating && !_isRotated)
        {
            transform.Rotate(m_pivot.up, Mathf.Lerp(transform.localRotation.y, _doorOpenRotation, _doorSpeed * Time.deltaTime));

            if (transform.localRotation.y < _doorOpenRotation) return;

            //_isRotating = false;
            _isRotated = true;
        }
        else if (_isRotating && _isRotated)
        {
            transform.Rotate(m_pivot.up, Mathf.Lerp(transform.localRotation.y, -_doorOpenRotation, _doorSpeed * Time.deltaTime));

            if (transform.localRotation.y > _doorOpenRotation) return;

            //_isRotating = false;
            _isRotated = false;
        }

        //Vector3 currentRotation = _doorTransform.localEulerAngles;
        //if (currentRotation.y < _doorOpenRotation)
        //{
        //    _doorTransform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, _doorOpenRotation, currentRotation.z), _doorSpeed * Time.deltaTime);
        //}
        //_isRotating = false;
        //else
        //{
        //    if (currentRotation.y > _doorCloseRotation)
        //    {
        //        _doorTransform.localEulerAngles = Vector3.Lerp(currentRotation, new Vector3(currentRotation.x, _doorCloseRotation, currentRotation.z), _doorSpeed * Time.deltaTime);
        //    }
        //}
    }

    public void ToggleDoor()
    {
        _isRotating = !_isRotating;
    }


    [SerializeField] private float _doorSpeed;
    [SerializeField] private float _doorCloseRotation;
    [SerializeField] private float _doorOpenRotation;


    private Transform _doorTransform;
    private bool _isRotating = false;
    private bool _isRotated = false;
}
