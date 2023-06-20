using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform m_camera;
    public Transform m_portal;
    public Transform m_otherPortal;

    private void Update()
    {
        Vector3 playerOffsetfromPortal = m_camera.position - m_otherPortal.position;
        transform.position = m_portal.position + playerOffsetfromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(m_portal.rotation, m_otherPortal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationDifference * m_camera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}