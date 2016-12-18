using UnityEngine;
using System.Collections;

public class Rewindable : MonoBehaviour {

    [SerializeField] private bool m_rewindPos = false;
    [SerializeField] private bool m_rewindRot = false;
    [SerializeField] private bool m_rewindMat = false;
    [SerializeField] private bool m_rewindBombHolder = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
