using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchThroughFloor : MonoBehaviour
{
    [SerializeField]
    private Collider m_floorToFallThrough;

    private void OnGUI()
    {
        if (GUILayout.Button("Glitch"))
        {
            Glitch();
        }
    }

    private void Glitch()
    {
        m_floorToFallThrough.isTrigger = true;
    }
}