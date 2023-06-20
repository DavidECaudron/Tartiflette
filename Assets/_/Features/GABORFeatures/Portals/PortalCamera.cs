using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    public Transform m_playerCamera;
    public Transform m_portal;
    public Transform m_otherPortal;

    private void Update()
    {
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(m_portal.rotation, m_otherPortal.rotation);

        Quaternion portalRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = /*portalRotationDifference **/ m_playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(new Vector3(newCameraDirection.x, newCameraDirection.y, newCameraDirection.z), Vector3.up);
    }
}