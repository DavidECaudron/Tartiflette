using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItemsSolid : MonoBehaviour
{
  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Player")) return;
    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
  }
}
