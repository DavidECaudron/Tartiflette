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
        //foreach (var key in m_keys)
        //{
        //    Debug.Log("check");
        //    if (key.ToString() == other.tag)
        //    {
        //        TransformObject(key.ToString(), other.gameObject);
        //    }
        //}
        switch (m_keys)
        {
            case Keys.ObjectA:
                TransformObject("ObjectA", other);
                break;

            case Keys.ObjectB:
                TransformObject("ObjectB", other);
                break;

            case Keys.ObjectC:
                TransformObject("ObjectC", other);
                break;

            default:
                break;
        }
    }

    private void TransformObject(string name, GameObject other)
    {
        if (!other.CompareTag(name))
        {
            return;
        }

        //foreach (var outputs in m_outPuts)
        //{
        //    Debug.Log("out");
        //    if (outputs.ToString() != name)
        //    {
        //        Debug.Log(other);
        //        if (outputs.ToString() == "ObjectA")
        //        {
        //            other.transform.parent.GetComponent<ActivateItems>().ActivateItemA();
        //            other.transform.parent.position = m_arrivalPoint.position;
        //        }
        //        else if (outputs.ToString() == "ObjectB")
        //        {
        //            other.transform.parent.transform.GetComponent<ActivateItems>().ActivateItemB();
        //            other.transform.parent.position = m_arrivalPoint.position;
        //        }
        //        else if (outputs.ToString() == "ObjectC")
        //        {
        //            other.transform.parent.transform.GetComponent<ActivateItems>().ActivateItemC();
        //            other.transform.parent.position = m_arrivalPoint.position;
        //        }
        //    }
        //}
        switch (m_outPuts)
        {
            case OutPuts.ObjectA:
                other.transform.parent.GetComponent<ActivateItems>().ActivateItemA();
                other.transform.parent.position = m_arrivalPoint.position;
                break;

            case OutPuts.ObjectB:
                other.transform.parent.GetComponent<ActivateItems>().ActivateItemB();
                other.transform.parent.position = m_arrivalPoint.position;
                break;

            case OutPuts.ObjectC:
                other.transform.parent.GetComponent<ActivateItems>().ActivateItemC();
                other.transform.parent.position = m_arrivalPoint.position;
                break;

            default:
                break;
        }
    }
}