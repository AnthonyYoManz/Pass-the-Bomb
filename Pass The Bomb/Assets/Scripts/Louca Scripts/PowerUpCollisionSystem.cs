using UnityEngine;
using System.Collections;

public class PowerUpCollisionSystem : MonoBehaviour {

    private ParticleSpawner m_particleSpawner;

    public GameObject m_audioObjectOne, m_audioObjectTwo;
    public int m_max, m_num;

	// Use this for initialization
	void Start () {
        m_particleSpawner = gameObject.GetComponent<ParticleSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_particleSpawner.SpawnParticle();
            int rand = (int)Random.Range(0, m_max);
            if (rand < m_num)
            {
                Instantiate(m_audioObjectOne, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(m_audioObjectTwo, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }

}
