using System;
using UnityEngine;

public enum Autorisations
{
    ObjectOnly,
    PlayerOnly,
    EveryBody
}

public enum Keys
{
    ObjectA,
    ObjectB,
    ObjectC
}

public enum OutPuts
{
    ObjectA,
    ObjectB,
    ObjectC
}

public class TpToArrivalPoint : MonoBehaviour
{
    public Autorisations m_autorisations = Autorisations.EveryBody;

    public Keys[] m_keys;
    public OutPuts[] m_outPuts;

    public Transform m_arrivalPoint;
    public Transform m_objectArrivalPoint;
    public Transform m_player;
    public GameObject m_objectA;
    public GameObject m_objectB;
    public GameObject m_objectC;
    
    public bool _isOtherPortalfacingTheSameDirection;
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
            TeleportPlayer(other);
            
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

        TeleportPlayer(other);
    }

    private void TeleportPlayer(GameObject other)
    {
        switch (_isOtherPortalfacingTheSameDirection)
        {
            case true:
                other.transform.position = m_arrivalPoint.position;
                other.transform.Rotate(Vector3.up, 180f);
                break;
            case false:
                other.transform.position = m_arrivalPoint.position;
                break;
        }
    }

    private void CheckIfKeyIsRight(GameObject other)
    {
        foreach (var key in m_keys)
        {
            Debug.Log("check");
            if (key.ToString() == other.tag)
            {
                TransformObject(key.ToString(), other.gameObject);
            }
        }
        //switch (m_keys)
        //{
        //    case Keys.ObjectA:
        //        TransformObject("ObjectA", other);
        //        break;

        //    case Keys.ObjectB:
        //        TransformObject("ObjectB", other);
        //        break;

        //    case Keys.ObjectC:
        //        TransformObject("ObjectC", other);
        //        break;

        //    default:
        //        break;
        //}
    }

    private void TransformObject(string name, GameObject other)
    {
        //if (!other.CompareTag(name))
        //{
        //    return;
        //}

        foreach (var outputs in m_outPuts)
        {
            Debug.Log("out");
            if (outputs.ToString() != name)
            {
                Debug.Log(other);
                if (outputs.ToString() == "ObjectA")
                {
                    Destroy(other);
                    Instantiate(m_objectA, m_objectArrivalPoint.position + Vector3.one, Quaternion.identity);
                }
                else if (outputs.ToString() == "ObjectB")
                {
                    Destroy(other);
                    Instantiate(m_objectB, m_objectArrivalPoint.position + Vector3.one, Quaternion.identity);
                }
                else if (outputs.ToString() == "ObjectC")
                {
                    Destroy(other);
                    Instantiate(m_objectC, m_objectArrivalPoint.position + Vector3.one, Quaternion.identity);
                }
            }
        }
        //switch (m_outPuts)
        //{
        //    case OutPuts.ObjectA:
        //        other.transform.parent.GetComponent<ActivateItems>().ActivateItemA();
        //        other.transform.parent.position = m_arrivalPoint.position;
        //        break;

        //    case OutPuts.ObjectB:
        //        other.transform.parent.GetComponent<ActivateItems>().ActivateItemB();
        //        other.transform.parent.position = m_arrivalPoint.position;
        //        break;

        //    case OutPuts.ObjectC:
        //        other.transform.parent.GetComponent<ActivateItems>().ActivateItemC();
        //        other.transform.parent.position = m_arrivalPoint.position;
        //        break;

        //    default:
        //        break;
        //}
    }
}