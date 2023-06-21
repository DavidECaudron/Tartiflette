using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class HalwayMover : MonoBehaviour
{
    #region Private and Protected

    public InfiniteHallwayManager _manager;
    private float _hallSize;

    #endregion Private and Protected

    #region Unity API

    private void Awake()
    {
        _hallSize = _manager.m_halls[0].transform.GetChild(0).localScale.x;
    }

    #endregion Unity API

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) { return; }

        if (other.gameObject.GetComponent<Rigidbody>().velocity.x > 0)
        {
            Vector3 currentPos = _manager.m_halls[_manager.m_halls.Count - 1].transform.position;
            _manager.m_halls[0].transform.position = new Vector3(currentPos.x + _hallSize, currentPos.y, currentPos.z);
            _manager.SortHalls();
        }
        else
        {
            Vector3 currentPos = _manager.m_halls[0].transform.position;
            _manager.m_halls[_manager.m_halls.Count - 1].transform.position = new Vector3(currentPos.x - _hallSize, currentPos.y, currentPos.z);
            _manager.SortHalls();
        }
    }
}