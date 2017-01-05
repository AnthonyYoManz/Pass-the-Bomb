using UnityEngine;
using System.Collections;

public class Rewind : MonoBehaviour {

    private Rewindable m_rewindable;
    [SerializeField]
    private float m_rateOfChange;
    private int m_counter;
    private bool m_counterSet;
    private bool m_isRewinding;

    // Use this for initialization
    void Start()
    {
        m_rewindable = GetComponent<Rewindable>();
        m_counterSet = false;
        m_isRewinding = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //rewind objects position
    public void RewindPos()
    {
        print("rewinding pos");
        //for (int i = m_rewindable.GetPosListCount() - 1; i >= 0; i--)
        //{
        //    print("index: " + i);
        //    transform.position = m_rewindable.GetPos(i);
        //}

        if (!m_counterSet)
        {
            print("setting counter");
            m_counter = m_rewindable.GetPosListCount() - 1;
            m_counterSet = true;
        }
        print("Counter: " + m_counter);
        if (transform.position == m_rewindable.GetPos(m_counter) && m_counter > 0)
        {
            m_counter--;
        }
        transform.position = Vector3.MoveTowards(transform.position, m_rewindable.GetPos(m_counter), Time.deltaTime * m_rateOfChange);

        if (m_counter < 0)
        {
            m_counter = 0;
        }
    }

    //rewind objects rotation
    public void RewindRot()
    {
        for (int i = m_rewindable.GetRotListCount() - 1; i >= 0; i--)
        {
            //print("index: " + i);
            transform.rotation = m_rewindable.GetRot(i);
        }
    }

    //rewind objects material
    public void RewindMat()
    {

    }

    //rewind bomb holder and should only be used by the bomb gameobject
    public void RewindBombHolder()
    {

    }

    public void ResetDirtyFlags()
    {
        m_counterSet = false;
    }
}
