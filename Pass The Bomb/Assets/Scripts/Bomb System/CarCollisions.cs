using UnityEngine;
using System.Collections;

public class CarCollisions : MonoBehaviour {

    public Bomb_System m_BombSystem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collision other)
    {
        if (m_BombSystem.m_BS == BombState.BS_NULL)
        {
            m_BS = BombState.BS_SPAWN;
        }
        m_SPNum++;
    }
}
