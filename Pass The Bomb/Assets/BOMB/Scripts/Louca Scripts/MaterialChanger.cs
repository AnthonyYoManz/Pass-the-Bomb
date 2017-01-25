using UnityEngine;
using System.Collections;

public class MaterialChanger : MonoBehaviour {

    public Material[] m_materials;
    private Material[] m_renderersMats;
    public int m_matNum;
    private int m_index, m_indexMax;
    public KeyCode m_nextMatKC, m_prevMatKC;
    private Renderer m_renderer;

	// Use this for initialization
	void Start () {
        m_renderer = gameObject.GetComponent<Renderer>();
        m_renderersMats = m_renderer.materials;
        m_index = 0;
        m_indexMax = m_materials.Length;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(m_nextMatKC))
        {
            MoveIndexUp();
            UpdateMat();
        }
        if (Input.GetKeyDown(m_prevMatKC))
        {
            MoveIndexDown();
            UpdateMat();
        }
	}

    void UpdateMat()
    {
        m_renderersMats[m_matNum] = m_materials[m_index];
        m_renderer.materials = m_renderersMats;
    }

    void MoveIndexUp()
    {
        if (m_index < m_indexMax)
        {
            m_index++;
        }
        if (m_index >= m_indexMax)
        {
            m_index = 0;
        }
    }

    void MoveIndexDown()
    {
        if (m_index <= 0)
        {
            m_index = m_indexMax;
        }
        if (m_index > 0)
        {
            m_index--;
        }
    }
}
