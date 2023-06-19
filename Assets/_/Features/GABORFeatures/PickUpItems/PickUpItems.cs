using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    #region Public Members

    public Transform m_pickUpTarget;
    public Camera m_camera;
    public float m_pickUpRange;
    public LayerMask m_layerMask;
    public Rigidbody m_rigidbody;

    #endregion Public Members

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (m_rigidbody)
            {
                m_rigidbody.useGravity = true;
                m_rigidbody = null;
                return;
            }

            Ray ray = m_camera.ViewportPointToRay(new Vector3(.5f, .5f, .5f));
            if (Physics.Raycast(ray, out RaycastHit hit, m_pickUpRange, m_layerMask))
            {
                m_rigidbody = hit.rigidbody;
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