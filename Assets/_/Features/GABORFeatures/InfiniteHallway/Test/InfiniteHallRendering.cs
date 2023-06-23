using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteHallRendering : MonoBehaviour
{
    public Transform m_playerCamera;
    public Transform m_portal;
    public Transform m_otherPortal;
    private void Update()
    {
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(m_portal.rotation, m_otherPortal.rotation);

        var newCameraDirection = /*portalRotationDifference **/m_playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(new Vector3(newCameraDirection.x, -newCameraDirection.y, newCameraDirection.z), Vector3.up);
        
    }
}
