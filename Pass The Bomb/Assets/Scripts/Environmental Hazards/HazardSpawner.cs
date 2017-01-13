using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HazardSpawner : MonoBehaviour {


    public Transform[] m_spawnHazard;
    public GameObject m_hazard;
    public List<GameObject> m_spawnedHazards;

    // Use this for initialization
    void Start()
    {
        SpawnHazards();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnHazards()
    {
        for (int i = 0; i < m_spawnHazard.Length; i++)
        {
            GameObject m_tempGameObjects = (GameObject)Instantiate(m_hazard, m_spawnHazard[i].transform.position, m_spawnHazard[i].transform.rotation);
        }
    }
}
