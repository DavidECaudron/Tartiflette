using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator m_playerAnimator;
    public Rigidbody m_playerRigidbody;
    
    private void Update()
    {
        m_playerAnimator.SetFloat("Speed", Mathf.Abs(m_playerRigidbody.velocity.x));
    }
}
