using UnityEngine;
using System.Collections;

public class PowerUpCollisionSystem : MonoBehaviour {

    private AudioSource m_audioSource;
    private ParticleSpawner m_particleSpawner;
    public AudioClip m_audioClip;
    public Camera m_camera;

	// Use this for initialization
	void Start () {
        m_audioSource = gameObject.GetComponent<AudioSource>();
        m_particleSpawner = gameObject.GetComponent<ParticleSpawner>();
        m_audioSource.clip = m_audioClip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            m_particleSpawner.SpawnParticle();
            gameObject.transform.position = m_camera.transform.position;
            PlayAudio();
        }
    }

    void PlayAudio()
    {
        m_audioSource.Play();
    }
}
