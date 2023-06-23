using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpToLevel : MonoBehaviour
{
    public Transform m_tpTarget;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.transform.position = m_tpTarget.position;
    }
}
