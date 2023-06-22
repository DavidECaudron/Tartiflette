using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetItemAsChild : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObjectA") || collision.gameObject.CompareTag("ObjectB") || collision.gameObject.CompareTag("ObjectC"))
        {
            collision.transform.SetParent(transform);
        }
    }
}