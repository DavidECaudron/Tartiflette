using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Autorisations
{
    ObjectOnly,
    PlayerOnly,
    EveryBody
}

public enum Keys
{
    ItemA,
    ItemB,
    ItemC
}

public enum OutPuts
{
    ItemA,
    ItemB,
    ItemC
}

public class TpToArrivalPoint : MonoBehaviour
{
    public Autorisations m_autorisations = Autorisations.EveryBody;
    public Keys m_keys;
    public OutPuts m_outPuts;
    public Transform m_arrivalPoint;
    public ActivateItems m_itemActivator;

    private void OnTriggerEnter(Collider other)
    {
        switch (m_autorisations)
        {
            case Autorisations.ObjectOnly:
                CheckIfKeyIsRight(other.gameObject);
                break;

            case Autorisations.PlayerOnly:
                TpPlayer(other.gameObject);
                break;

            case Autorisations.EveryBody:
                TpEverybody(other.gameObject);
                break;

            default:
                break;
        }
    }

    private void TpEverybody(GameObject other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Object"))
        {
            other.transform.position = m_arrivalPoint.position;
        }
    }

    private void TpPlayer(GameObject other)
    {
        if (!other.CompareTag("Player")) { return; }

        other.transform.position = m_arrivalPoint.position;
    }

    private void CheckIfKeyIsRight(GameObject other)
    {
        switch (m_keys)
        {
            case Keys.ItemA:
                TransformObject("ItemA", other);
                break;

            case Keys.ItemB:
                TransformObject("ItemB", other);
                break;

            case Keys.ItemC:
                TransformObject("ItemC", other);
                break;

            default:
                break;
        }

        other.transform.position = m_arrivalPoint.position;
    }

    private void TransformObject(string name, GameObject other)
    {
        if (!other.CompareTag(name)) { return; }

        switch (m_outPuts)
        {
            case OutPuts.ItemA:
                m_itemActivator.ActivateItemA();
                break;

            case OutPuts.ItemB:
                m_itemActivator.ActivateItemB();
                break;

            case OutPuts.ItemC:
                m_itemActivator.ActivateItemC();
                break;

            default:
                break;
        }
    }
}