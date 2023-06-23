using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallStart : MonoBehaviour
{
    public Collider m_floorToFallThrough;
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        m_floorToFallThrough.isTrigger = false;
    }
    
}
