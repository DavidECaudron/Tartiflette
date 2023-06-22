using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateItemIfEmpty : MonoBehaviour
{
    public GameObject m_carriableObject;
    public Transform m_itemContainer;

    public void GenerateIfItemTaken()
    {
        if (m_itemContainer.childCount == 0)
        {
            Instantiate(m_carriableObject, m_itemContainer.position, Quaternion.identity, m_itemContainer);
        }
    }
}