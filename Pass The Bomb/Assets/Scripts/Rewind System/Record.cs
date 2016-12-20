using UnityEngine;
using System.Collections;

public class Record : MonoBehaviour {

    private Rewindable m_rewindable;
    private Vector3 m_lastPos;
    private Quaternion m_lastRot;
    private Material m_lastMat;
    private GameObject m_lastBombHolder;

	// Use this for initialization
	void Start () {
        m_rewindable = GetComponent<Rewindable>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //rewind objects position
    public void RecordPos()
    {
        if (gameObject.transform.position != m_lastPos)
        {
            m_rewindable.AddPos(gameObject.transform.position);
            m_lastPos = gameObject.transform.position;
        }
        if (m_rewindable.GetPosListCount() > m_rewindable.GetRecordLimit())
        {
            m_rewindable.RemoveFirstPosValue();
        }
    }

    //rewind objects rotation
    public void RecordRot()
    {
        if (gameObject.transform.rotation != m_lastRot)
        {
            m_rewindable.AddRot(gameObject.transform.rotation);
            m_lastRot = gameObject.transform.rotation;
        }
    }

    //rewind objects material
    public void RecordMat()
    {

    }

    //rewind bomb holder and should only be used by the bomb gameobject
    public void RecordBombHolder()
    {

    }
}
