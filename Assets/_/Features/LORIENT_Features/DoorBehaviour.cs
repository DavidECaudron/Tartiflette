using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private void Awake()
    {
        _doorTransform = GetComponent<Transform>();
        _pivotTransform = transform.GetChild(0).GetComponent<Transform>();
    }

    private void Update()
    {
    }

    public void DoorInteraction()
    {
        if (!_isOpen)
        {
            Debug.Log("test");
            Debug.Log(_doorTransform.rotation);
            Debug.Log(_pivotTransform.rotation);
            _doorTransform.rotation = Quaternion.Lerp(_doorTransform.rotation, _pivotTransform.localRotation, _doorSpeed * Time.deltaTime);
            _isOpen = true;
        }

        else if (_isOpen)
        {
            _doorTransform.rotation = Quaternion.Lerp(_doorTransform.rotation, _pivotTransform.localRotation, _doorSpeed * Time.deltaTime);
            _isOpen = false;
        }
    }


    [SerializeField] private float _doorSpeed;
    private Transform _doorTransform;
    private Transform _pivotTransform;
    private bool _isOpen;
}
