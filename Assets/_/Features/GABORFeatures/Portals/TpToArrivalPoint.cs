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
    Cube,
    BiggerCube,
    Sphere
}

public class TpToArrivalPoint : MonoBehaviour
{
    public Autorisations m_autorisations = Autorisations.EveryBody;
    public Transform m_arrivalPoint;

    private void OnTriggerEnter(Collider other)
    {
        switch (m_autorisations)
        {
            case Autorisations.ObjectOnly:
                TpObject(other.gameObject);
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
            Debug.Log("gone");
            other.transform.position = m_arrivalPoint.position;
        }
    }

    private void TpPlayer(GameObject other)
    {
        if (!other.CompareTag("Player")) { return; }

        other.transform.position = m_arrivalPoint.position;
    }

    private void TpObject(GameObject other)
    {
        if (!other.CompareTag("Object")) { return; }

        other.transform.position = m_arrivalPoint.position;
    }
}