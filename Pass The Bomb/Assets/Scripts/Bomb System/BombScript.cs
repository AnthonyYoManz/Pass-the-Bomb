using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour
{
    //bomb System
    private Bomb_System m_BombSystem;
    private GameObject m_bombSystemObject;

    private ExplosionPhysics m_ExpPhy;
   /* private ExplosionPhysics m_ExpPhysic;
    private GameObject m_ExpPhysicObject;*/
    //Particale
    private ParticleSpawner m_ParticleSpawner ;
    private ParticleKiller m_ParticleKiller;
    private GameObject m_ParticlespawnerObject ;
    //Score
    //private  ;
    //private  ;
    //add refence to BombHolderComponent

    // Use this for initialization
    private bool m_initCol;

    public float m_val;

    public float m_Timer;
    public float m_TimeLimit;

    public Vector3 tempPos;

    void Start()
    {
        m_bombSystemObject = GameObject.FindGameObjectWithTag("BombSystem");
        m_BombSystem =  m_bombSystemObject.GetComponent<Bomb_System>();
       /* m_ExpPhysicObject = GameObject.FindGameObjectWithTag("ExplosionsPhysics");
        m_ExpPhysic = m_ExpPhysicObject.GetComponent<ExplosionPhysics>();*/

        m_ParticleSpawner = GetComponent<ParticleSpawner>();
        m_ExpPhy = GetComponent<ExplosionPhysics>();
       



        m_initCol = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_initCol)
        {
            TimeSystem();
        }
    }

    

    void OnTriggerEnter(Collider other)
    {
       
        if((other.tag == "Player")&&(m_initCol == false))
        {
            m_initCol = true;
            tempPos = other.gameObject.transform.position;
            print(tempPos);
            gameObject.transform.position = new Vector3(tempPos.x, tempPos.y + m_val, tempPos.z);
            gameObject.transform.parent = other.gameObject.transform;
        }
    }

    void TimeSystem()
    {
        
        m_Timer += Time.deltaTime;
        if (m_Timer > m_TimeLimit)
        {

            gameObject.transform.position = new Vector3(tempPos.x, tempPos.y - m_val, tempPos.z);
            m_ExpPhy.trigger();
            //spawn particle
            Destroy(gameObject);
            m_initCol = false;
            m_BombSystem.SetBombSpawn(true);
            m_ParticleSpawner.SpawnParticle();

           
            
            
        }
    }
}
