using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateItems : MonoBehaviour
{
    public GameObject m_itemA;
    public GameObject m_itemB;
    public GameObject m_itemC;

    public void ActivateItemA()
    {
        m_itemA.SetActive(true);
        m_itemB.SetActive(false);
        m_itemC.SetActive(false);
    }

    public void ActivateItemB()
    {
        m_itemA.SetActive(false);
        m_itemB.SetActive(true);
        m_itemC.SetActive(false);
    }

    public void ActivateItemC()
    {
        m_itemA.SetActive(false);
        m_itemB.SetActive(false);
        m_itemC.SetActive(true);
    }
}