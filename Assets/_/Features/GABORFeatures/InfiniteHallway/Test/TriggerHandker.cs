using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandker : MonoBehaviour
{
    public InfiniteHallWayTest m_manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            m_manager.CheckIfEqualNumberBothSides();
        }
    }
}