using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rewindable : MonoBehaviour {

    [SerializeField] private bool m_rewindPos = false;
    [SerializeField] private bool m_rewindRot = false;
    [SerializeField] private bool m_rewindMat = false;
    [SerializeField] private bool m_rewindBombHolder = false;
    [SerializeField] private List<Vector3> m_recordedPos;
    [SerializeField] private List<Quaternion> m_recordedRot;
    [SerializeField] private List<Material> m_recordedMat;
    [SerializeField] private List<GameObject> m_recordedBombHolder;
    private int m_recordLimit;

    // Use this for initialization
    void Start () {
        m_recordedPos = new List<Vector3>();
        m_recordedRot = new List<Quaternion>();
        m_recordedMat = new List<Material>();
        m_recordedBombHolder = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void ResetData()
    {
        m_recordedPos.Clear();
        m_recordedRot.Clear();
        m_recordedMat.Clear();
        m_recordedBombHolder.Clear();
    }

    public void SetRecordLimit(int _newLimit)
    {
        m_recordLimit = _newLimit;
    }

    public int GetRecordLimit()
    {
        return m_recordLimit;
    }

    public bool GetPosBool()
    {
        return m_rewindPos;
    }

    public bool GetRotBool()
    {
        return m_rewindRot;
    }

    public bool GetMatBool()
    {
        return m_rewindMat;
    }

    public bool GetBombHolderBool()
    {
        return m_rewindBombHolder;
    }

    public void AddPos(Vector3 _newPos)
    {
        m_recordedPos.Add(_newPos);
    }

    public void AddRot(Quaternion _newRot)
    {
        m_recordedRot.Add(_newRot);
    }

    public Vector3 GetPos(int _index)
    {
        return m_recordedPos[_index];
    }

    public Quaternion GetRot(int _index)
    {
        return m_recordedRot[_index];
    }

    public int GetPosListCount()
    {
        return m_recordedPos.Count;
    }

    public void RemoveFirstPosValue()
    {
        m_recordedPos.RemoveAt(0);
    }

    public int GetRotListCount()
    {
        return m_recordedRot.Count;
    }

    public void RemoveFirstRotValue()
    {
        m_recordedRot.RemoveAt(0);
    }
}
