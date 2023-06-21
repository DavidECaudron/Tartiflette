using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangePointMovement : MonoBehaviour
{
    public Transform m_player;

    private void Update()
    {
        transform.position = new Vector3(m_player.position.x, transform.position.y, transform.position.z);
    }
}