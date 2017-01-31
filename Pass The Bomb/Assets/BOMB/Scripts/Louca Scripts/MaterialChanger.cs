using UnityEngine;
using System.Collections;

public class MaterialChanger : MonoBehaviour {

    public Material m_initMat, m_bombHolderMat;
    private Material[] m_renderersMats;
    public int m_matNum;
    private Renderer m_renderer;

	// Use this for initialization
	void Start () {
        m_renderer = gameObject.GetComponent<Renderer>();
        m_renderersMats = m_renderer.materials;
        m_initMat = m_renderersMats[m_matNum];
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void UpdateMatToInitMat()
    {
        m_renderersMats[m_matNum] = m_initMat;
        m_renderer.materials = m_renderersMats;
    }

    public void UpdateMatToBHMat()
    {
        m_renderersMats[m_matNum] = m_bombHolderMat;
        m_renderer.materials = m_renderersMats;
    }
}
