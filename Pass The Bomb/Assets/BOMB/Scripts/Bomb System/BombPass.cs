using UnityEngine;
using System.Collections;

public class BombPass : MonoBehaviour {

    [SerializeField]
    private bool m_holdingBomb = false, m_timerStart;
    [SerializeField]
    private MaterialChanger m_matChangerScript;
    [SerializeField]
    private GameObject m_bomb;
    private float m_timer;
    [SerializeField]
    private float m_timeInterval;
    private GameObject m_playerHit;


	// Use this for initialization
	void Start () {
        m_holdingBomb = false;
        m_timerStart = false;
        m_matChangerScript = GetComponent<MaterialChanger>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (m_timerStart)
        {
            Timer();
        }
	}

    void OnCollisionExit(Collision col)
    {
        if (m_holdingBomb)
        {
            if (col.collider.tag == "Player")
            {
                m_playerHit = col.gameObject;
                m_timerStart = true;
            }
        }
    }

    void Timer()
    {
        if (m_timer > m_timeInterval)
        {
            //need to add a delay to the pass
            if (m_bomb.GetComponent<BombScript>())
            {
                m_bomb.GetComponent<BombScript>().SetNewBombHolder(m_playerHit);
            }
            m_matChangerScript.UpdateMatToInitMat();
            m_playerHit = null;
            m_bomb = null;
            m_holdingBomb = false;
            m_timer = 0;
            m_timerStart = false;
        }

        m_timer += Time.deltaTime;
    }

    public bool GetHoldingBomb()
    {
        return m_holdingBomb;
    }

    public void SetHoldingBomb(bool _newValue, GameObject _bomb)
    {
        m_holdingBomb = _newValue;
        m_bomb = _bomb;
    }
}
