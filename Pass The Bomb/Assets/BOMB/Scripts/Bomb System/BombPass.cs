using UnityEngine;
using System.Collections;

public class BombPass : MonoBehaviour {

    [SerializeField]
    private bool m_holdingBomb = false;
    [SerializeField]
    private MaterialChanger m_matChangerScript;
    [SerializeField]
    private GameObject m_bomb;

	// Use this for initialization
	void Start () {
        m_holdingBomb = false;
        m_matChangerScript = GetComponent<MaterialChanger>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionExit(Collision col)
    {
        if (m_holdingBomb)
        {
            if (col.collider.tag == "Player")
            {
                if (m_bomb.GetComponent<BombScript>())
                {
                    m_bomb.GetComponent<BombScript>().SetNewBombHolder(col.gameObject);
                }
                m_matChangerScript.UpdateMatToInitMat();
                m_bomb = null;
                m_holdingBomb = false;
            }
        }
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
