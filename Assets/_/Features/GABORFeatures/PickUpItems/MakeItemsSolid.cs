using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItemsSolid : MonoBehaviour
{
    public GameObject m_passerelle;
    public bool m_doItYourself;
    public int m_count;

  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Player")) return;
        switch (m_doItYourself)
        {
            case true: other.rigidbody.isKinematic = true; break;
            case false: m_count++;  SpawnPasserelle(); break;
        }
  }
    private void SpawnPasserelle()
    {
        if (m_count != 2) return;
        m_passerelle.SetActive(true);
    }
}
