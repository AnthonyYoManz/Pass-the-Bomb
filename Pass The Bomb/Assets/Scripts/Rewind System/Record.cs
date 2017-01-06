using UnityEngine;
using System.Collections;

public class Record : MonoBehaviour {

    private Rewindable m_rewindable;
    private Vector3 m_lastPos;
    private Quaternion m_lastRot;
    private Material m_lastMat;
    private GameObject m_lastBombHolder;
    private float m_posTimer, m_rotTimer;
    [SerializeField] private float m_timeInterval;
	// Use this for initialization
	void Start () {
        m_rewindable = GetComponent<Rewindable>();
        m_posTimer = 0.0f;
        m_rotTimer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //rewind objects position
    public void RecordPos()
    {
        if (m_posTimer > m_timeInterval)
        {
            //Do Stuff
            if (gameObject.transform.position != m_lastPos)
            {
                m_rewindable.AddPos(gameObject.transform.position);
                m_lastPos = gameObject.transform.position;
            }
            m_posTimer = 0;
        }
        m_posTimer += Time.deltaTime;
        
        if (m_rewindable.GetPosListCount() > m_rewindable.GetRecordLimit())
        {
            m_rewindable.RemoveFirstPosValue();
        }
    }

    //rewind objects rotation
    public void RecordRot()
    {
        if (m_rotTimer > m_timeInterval)
        {
            if (gameObject.transform.rotation != m_lastRot)
            {
                m_rewindable.AddRot(gameObject.transform.rotation);
                m_lastRot = gameObject.transform.rotation;
            }
            m_rotTimer = 0;
        }

        m_rotTimer += Time.deltaTime;

        if (m_rewindable.GetRotListCount() > m_rewindable.GetRecordLimit())
        {
            m_rewindable.RemoveFirstRotValue();
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
