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
        if (other.CompareTag("Player"))
        {
            other.transform.position = m_arrivalPoint.position;
        }
        else if (other.CompareTag("ObjectA") || other.CompareTag("ObjectB") || other.CompareTag("ObjectC"))
        {
            CheckIfKeyIsRight(other.gameObject);
        }
        else
        {
            return;
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
                TransformObject("ObjectA", other);
                break;

            case Keys.ItemB:
                TransformObject("ObjectB", other);
                break;

            case Keys.ItemC:
                TransformObject("ObjectC", other);
                break;

            default:
                break;
        }
    }

    private void TransformObject(string name, GameObject other)
    {
        Debug.Log(other.tag);
        if (!other.CompareTag(name)) { return; }

        switch (m_outPuts)
        {
            case OutPuts.ItemA:
                other.transform.parent.GetComponent<ActivateItems>().ActivateItemA();
                other.transform.parent.position = m_arrivalPoint.position;
                break;

            case OutPuts.ItemB:
                other.transform.parent.GetComponent<ActivateItems>().ActivateItemB();
                other.transform.parent.position = m_arrivalPoint.position;
                break;

            case OutPuts.ItemC:
                other.transform.parent.GetComponent<ActivateItems>().ActivateItemC();
                other.transform.parent.position = m_arrivalPoint.position;
                break;

            default:
                break;
        }
    }
}