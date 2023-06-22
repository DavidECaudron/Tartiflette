using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public enum Orientation
{
    x,
    y,
    z
}

public class InfiniteHallWayTest : MonoBehaviour
{
    #region Public Members

    public List<Transform> m_sections;
    public Orientation m_orientation;
    public Transform m_player;
    public float m_range;
    public float m_hallSize;
    public float m_offset;
    public float m_divider;

    public float m_refreshRate;

    #endregion Public Members

    #region Unity API

    private void Start()
    {
        SortHalls();
        StartCoroutine(Timer());
        m_offset = ((m_sections.Count * m_hallSize) / m_divider);
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            CheckIfEqualNumberBothSides();
            yield return new WaitForSeconds(m_refreshRate);
        }
    }

    private void SortHalls()
    {
        switch (m_orientation)
        {
            case Orientation.x:
                m_sections.Sort((x, y) => x.position.x.CompareTo(y.position.x));
                break;

            case Orientation.y:
                m_sections.Sort((x, y) => x.position.y.CompareTo(y.position.y));
                break;

            case Orientation.z:
                m_sections.Sort((x, y) => x.position.z.CompareTo(y.position.z));
                break;
        }
    }

    #endregion Unity API

    #region Main Methods

    public void CheckIfEqualNumberBothSides()
    {
        float distanceBehind = Vector3.Distance(m_player.position, m_sections[0].position);
        float distanceAhead = Vector3.Distance(m_player.position, m_sections[m_sections.Count - 1].position);

        if (distanceBehind <= m_range)
        {
            MoveBehind();
            return;
        }
        else if (distanceAhead <= m_range)
        {
            MoveAhead();
            return;
        }
    }

    private void SpawnIfEmpty()
    {
        foreach (var section in m_sections)
        {
            if (section.GetComponent<GenerateItemIfEmpty>() != null) { section.gameObject.GetComponent<GenerateItemIfEmpty>().GenerateIfItemTaken(); }
        }
    }

    private void MoveBehind()
    {
        switch (m_orientation)
        {
            case Orientation.x:
                Vector3 currentPosx = m_sections[0].transform.position;
                m_sections[m_sections.Count - 1].transform.position = new Vector3(currentPosx.x - m_hallSize, currentPosx.y, currentPosx.z);
                break;

            case Orientation.y:
                Vector3 currentPosy = m_sections[0].transform.position;
                m_sections[m_sections.Count - 1].transform.position = new Vector3(currentPosy.x, currentPosy.y - m_hallSize, currentPosy.z);
                break;

            case Orientation.z:
                Vector3 currentPosz = m_sections[0].transform.position;
                m_sections[m_sections.Count - 1].transform.position = new Vector3(currentPosz.x, currentPosz.y, currentPosz.z - m_hallSize);
                break;

            default:
                break;
        }
        SpawnIfEmpty();
        SortHalls();
    }

    private void MoveAhead()
    {
        switch (m_orientation)
        {
            case Orientation.x:
                Vector3 currentPosx = m_sections[m_sections.Count - 1].transform.position;
                m_sections[0].transform.position = new Vector3(currentPosx.x + m_hallSize, currentPosx.y, currentPosx.z);
                break;

            case Orientation.y:
                Vector3 currentPosy = m_sections[m_sections.Count - 1].transform.position;
                m_sections[0].transform.position = new Vector3(currentPosy.x, currentPosy.y + m_hallSize, currentPosy.z);
                break;

            case Orientation.z:
                Vector3 currentPosz = m_sections[m_sections.Count - 1].transform.position;
                m_sections[0].transform.position = new Vector3(currentPosz.x, currentPosz.y, currentPosz.z + m_hallSize);
                break;

            default:
                break;
        }
        SpawnIfEmpty();
        SortHalls();
    }

    #endregion Main Methods
}