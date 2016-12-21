using UnityEngine;
using System.Collections;

public class Rewind : MonoBehaviour {

    private Rewindable m_rewindable;

    // Use this for initialization
    void Start () {
        m_rewindable = GetComponent<Rewindable>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //rewind objects position
    public void RewindPos()
    {
        for (int i = m_rewindable.GetPosListCount() - 1; i >= 0; i--)
        {
            print("index: " + i);
            transform.position = m_rewindable.GetPos(i);
        }
    }

    //rewind objects rotation
    public void RewindRot()
    {
        for (int i = m_rewindable.GetRotListCount() - 1; i >= 0; i--)
        {
            print("index: " + i);
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
}
