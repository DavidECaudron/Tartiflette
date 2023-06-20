using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteHallwayManager : MonoBehaviour
{
    #region Public Members

    public static InfiniteHallwayManager instance;

    public List<GameObject> m_halls;

    #endregion Public Members

    #region Main Methods

    private void Awake()
    {
        if (instance == null) { instance = this; }

        SortHalls();
    }

    public void SortHalls()
    {
        m_halls.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x));
    }

    #endregion Main Methods
}