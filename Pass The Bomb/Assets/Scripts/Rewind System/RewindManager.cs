using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RewindManager : MonoBehaviour {

    private List<GameObject> m_rewindableGameObjects;
    public float m_timeToRewind;
    private bool rewind;

	// Use this for initialization
	void Start () {
        m_rewindableGameObjects = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        //if rewind true start rewind system
	    if (rewind)
        {
            Rewind();
            rewind = false; //set false so that it doesnt happen more than once
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
            else if (rewindable.GetComponent<Rewindable>().GetRotBool())
            {
                rewindable.GetComponent<Rewind>().RewindRot();
            }
            //if the object wants to rewind their mat then rewind mat
            else if (rewindable.GetComponent<Rewindable>().GetMatBool())
            {
                rewindable.GetComponent<Rewind>().RewindMat();
            }
            //if the object wants to rewind the bomb holder then rewind bomb holder
            else if (rewindable.GetComponent<Rewindable>().GetBombHolderBool())
            {
                rewindable.GetComponent<Rewind>().RewindBombHolder();
            }
        }
    }
}
