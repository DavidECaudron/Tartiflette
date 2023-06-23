using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchThroughFloor : MonoBehaviour
{
    [SerializeField]
    private Collider m_floorToFallThrough;
    [SerializeField] DoorAnimator _doorAnimator;

    public void Glitch()
    {
        _doorAnimator.ToggleDoor();
        Invoke("FallTroughTheFloor", 2f);
    }

    private void FallTroughTheFloor()
    {
        m_floorToFallThrough.isTrigger = true;
    }
}