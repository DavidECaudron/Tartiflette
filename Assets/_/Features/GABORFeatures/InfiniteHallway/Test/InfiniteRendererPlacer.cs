using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRendererPlacer : MonoBehaviour
{
    public GameObject m_endPlane;
    public GameObject m_startPlane;
    public InfiniteHallWayTest m_manager;
    public Transform m_player;

    private void Update()
    {
        m_endPlane.transform.position = new Vector3(m_player.position.x - m_manager.m_offset, m_endPlane.transform.position.y, m_endPlane.transform.position.z);
        m_startPlane.transform.position = new Vector3(m_player.position.x + m_manager.m_offset, m_startPlane.transform.position.y, m_startPlane.transform.position.z);
    }
}