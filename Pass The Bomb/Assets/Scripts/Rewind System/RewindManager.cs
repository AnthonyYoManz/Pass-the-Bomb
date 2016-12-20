using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewindManager : MonoBehaviour {

    public List<GameObject> m_rewindableGameObjects;
    public float m_timeToRewind;
    public int m_recordLimit;
    public enum Mode { Rewind, Record, Reset };
    public Mode mode = Mode.Record;
    private bool m_recordDirtyFlag;

    // Use this for initialization
    void Start () {
        //m_rewindableGameObjects = new List<GameObject>();
        m_recordDirtyFlag = false;
        foreach (GameObject rewindable in m_rewindableGameObjects)
        {
            rewindable.GetComponent<Rewindable>().SetRecordLimit(m_recordLimit);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mode = Mode.Rewind;
        }

        //if rewind true start rewind system
        if (mode == Mode.Rewind)
        {
            Rewind();
        }
        else if (mode == Mode.Record)
        {
            Record();
        }
        else if (mode == Mode.Reset)
        {
            ResetData();
        }
	}

    void Rewind()
    {
        //loop through each rewindable object and rewind specific traits
        foreach (GameObject rewindable in m_rewindableGameObjects)
        {
            //if the object wants to rewind their pos then rewind pos
            if (rewindable.GetComponent<Rewindable>().GetPosBool())
            {
                rewindable.GetComponent<Rewind>().RewindPos();
            }
            //if the object wants to rewind their rot then rewind rot
            if (rewindable.GetComponent<Rewindable>().GetRotBool())
            {
                rewindable.GetComponent<Rewind>().RewindRot();
            }
            //if the object wants to rewind their mat then rewind mat
            if (rewindable.GetComponent<Rewindable>().GetMatBool())
            {
                rewindable.GetComponent<Rewind>().RewindMat();
            }
            //if the object wants to rewind the bomb holder then rewind bomb holder
            if (rewindable.GetComponent<Rewindable>().GetBombHolderBool())
            {
                rewindable.GetComponent<Rewind>().RewindBombHolder();
            }
        }
        mode = Mode.Reset;
    }

    void Record()
    {
        //loop through each rewindable object and rewind specific traits
        foreach (GameObject rewindable in m_rewindableGameObjects)
        {
            //if the object wants to rewind their pos then rewind pos
            if (rewindable.GetComponent<Rewindable>().GetPosBool())
            {
                rewindable.GetComponent<Record>().RecordPos();
            }
            //if the object wants to rewind their rot then rewind rot
            if (rewindable.GetComponent<Rewindable>().GetRotBool())
            {
                rewindable.GetComponent<Record>().RecordRot();
            }
            //if the object wants to rewind their mat then rewind mat
            if (rewindable.GetComponent<Rewindable>().GetMatBool())
            {
                rewindable.GetComponent<Record>().RecordMat();
            }
            //if the object wants to rewind the bomb holder then rewind bomb holder
            if (rewindable.GetComponent<Rewindable>().GetBombHolderBool())
            {
                rewindable.GetComponent<Record>().RecordBombHolder();
            }
        }
    }

    void ResetData()
    {
        foreach (GameObject rewindable in m_rewindableGameObjects)
        {
            rewindable.GetComponent<Rewindable>().ResetData();
        }
        mode = Mode.Record;
    }
}
