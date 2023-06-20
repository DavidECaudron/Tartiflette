using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpItems : MonoBehaviour
{
    #region Public Members

    public Transform m_pickUpTarget;
    public Camera m_camera;
    public float m_pickUpRange;
    public LayerMask m_layerMask;
    public Rigidbody m_rigidbody;

    public InputAction m_actionButton;

    #endregion Public Members

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (m_rigidbody)
            {
                m_rigidbody.useGravity = true;
                m_rigidbody.transform.parent = null;
                m_rigidbody = null;
                return;
            }

            Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);
            if (Physics.Raycast(m_camera.transform.position, m_camera.transform.forward, out RaycastHit hit, m_pickUpRange, m_layerMask))
            {
                Debug.Log("yay");
                m_rigidbody = hit.rigidbody;
                m_rigidbody.transform.parent = m_pickUpTarget;
                m_rigidbody.useGravity = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (m_rigidbody)
        {
            Vector3 DirectionToPoint = m_pickUpTarget.position - m_rigidbody.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            m_rigidbody.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }
}