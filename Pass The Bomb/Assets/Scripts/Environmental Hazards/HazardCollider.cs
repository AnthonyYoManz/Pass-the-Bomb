using UnityEngine;
using System.Collections;

public class HazardCollider : MonoBehaviour {

    private ParticleSpawner m_particleSpawner;
    public Camera m_camera;

    // Use this for initialization
    void Start()
    {
        m_particleSpawner = gameObject.GetComponent<ParticleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            m_particleSpawner.SpawnParticle();
            gameObject.transform.position = m_camera.transform.position;
        }
    }

    //void PlayAudio()
    //{
    //    m_audioSource.Play();
    //}
}
