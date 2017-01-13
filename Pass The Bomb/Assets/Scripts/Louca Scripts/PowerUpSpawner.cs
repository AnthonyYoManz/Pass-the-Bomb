using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour {

    public Transform[] m_spawnPoint;
    public GameObject m_powerUp;
    public List<GameObject> m_SpawnedPowerUps;

	// Use this for initialization
	void Start () {
        SpawnPowerUps();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SpawnPowerUps()
    {
        for (int i = 0; i < m_spawnPoint.Length; i++)
        {
            GameObject m_tempGameObjects = (GameObject)Instantiate(m_powerUp, m_spawnPoint[i].transform.position, m_spawnPoint[i].transform.rotation);
        }
    }
}
