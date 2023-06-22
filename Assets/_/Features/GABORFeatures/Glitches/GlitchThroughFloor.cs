using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchThroughFloor : MonoBehaviour
{
    private bool _isGlitching;
    public Transform m_glitchPoint;

    public float m_glitchSpeed;

    private void OnGUI()
    {
        if (GUILayout.Button("Glitch"))
        {
            //_isGlitching = !_isGlitching;
            Glitch();
        }
    }

    private void Update()
    {
        if (_isGlitching)
        {
        }
    }

    private void Glitch()
    {
        transform.GetComponent<Collider>().enabled = false;
        transform.position = Vector3.Lerp(transform.position, m_glitchPoint.position, Mathf.Sin(Time.time * m_glitchSpeed));
        transform.GetComponent<Collider>().enabled = true;
    }
}