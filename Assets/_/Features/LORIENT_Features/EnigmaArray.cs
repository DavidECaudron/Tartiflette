using UnityEngine;

public class EnigmaArray : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        CheckFirstSnapPoint(other);
        CheckSecondSnapPoint(other);
        CheckIfWin();
    }

    private void CheckFirstSnapPoint(Collider other)
    {
        if (other.CompareTag(_firstKey.ToString()))
        {
            if (other.transform.parent == _playerTransform) return;
            if (Vector3.Distance(_firstSnapPointTransform.position, other.transform.position) > _snapDistance) return;
            other.transform.position = _firstSnapPointTransform.position;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.transform.SetParent(null);
            switch (_firstKey)
            {
                case ObjectType.ObjectA:
                    _objectA = true;
                    break;
                case ObjectType.ObjectB:
                    _objectB = true;
                    break;
                case ObjectType.ObjectC:
                    _objectC = true;
                    break;
            }
        }
    }

    private void CheckSecondSnapPoint(Collider other)
    {
        if (other.CompareTag(_secondKey.ToString()))
        {
            if (other.transform.parent == _playerTransform) return;
            if (Vector3.Distance(_secondSnapPointTransform.position, other.transform.position) > _snapDistance) return;
            other.transform.position = _secondSnapPointTransform.position;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.transform.SetParent(null);
            switch (_secondKey)
            {
                case ObjectType.ObjectA:
                    _objectA = true;
                    break;
                case ObjectType.ObjectB:
                    _objectB = true;
                    break;
                case ObjectType.ObjectC:
                    _objectC = true;
                    break;
            }
        }
    }

    private void CheckIfWin()
    {
        if (m_isGameEnded) return;
        if (!_objectA == m_objectA) return;
        if (!_objectB == m_objectB) return;
        if (!_objectC == m_objectC) return;

        m_menu.EndGameMenu();

        m_isGameEnded = true;
    }

    private enum ObjectType
    {
        ObjectA,
        ObjectB, 
        ObjectC
    }


    public static bool m_isGameEnded;

    public bool m_objectA;
    public bool m_objectB;
    public bool m_objectC;

    [SerializeField] private Menu m_menu;
    [SerializeField] private ObjectType _firstKey;
    [SerializeField] private ObjectType _secondKey;
    [SerializeField] private Transform _firstSnapPointTransform;
    [SerializeField] private Transform _secondSnapPointTransform;
    [SerializeField] private float _snapDistance;
    [SerializeField] private Transform _playerTransform;

    private bool _objectA;
    private bool _objectB;
    private bool _objectC;
}