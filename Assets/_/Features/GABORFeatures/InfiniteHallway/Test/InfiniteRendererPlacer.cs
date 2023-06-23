using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfiniteRendererPlacer : MonoBehaviour
{
    public GameObject m_endPlane;
    public GameObject m_startPlane;
    public float m_offset;
    public Transform m_player;

    private void Update()
    {
        var position = m_endPlane.transform.position;
        position = new Vector3(m_player.position.x - m_offset, position.y, position.z);
        m_endPlane.transform.position = position;
        
        var position1 = m_startPlane.transform.position;
        position1 = new Vector3(m_player.position.x + m_offset, position1.y, position1.z);
        m_startPlane.transform.position = position1;
    }
}