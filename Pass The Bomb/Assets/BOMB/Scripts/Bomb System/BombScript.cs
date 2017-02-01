using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour
{
    //bomb System
    private Bomb_System m_BombSystem;
    private GameObject m_bombSystemObject;

    private ExplosionPhysics m_ExpPhy;
    private ParticleSpawner m_ParticleSpawner ;
    private ParticleKiller m_ParticleKiller;
    private GameObject m_ParticlespawnerObject ;

    private GameObject m_Player;
    //Score
    //private  ;
    //private  ;
    //add refence to BombHolderComponent

    // Use this for initialization
    private bool m_initCol;

    public float m_val;
    [SerializeField]
    private float m_lowerVal, m_forwardVal;

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

        //if being held then constantly update its position
    }

    

    void OnTriggerEnter(Collider other)
    {
       
        if((other.tag == "Player")&&(m_initCol == false))
        {
            m_initCol = true;
            tempPos = other.gameObject.transform.position;
            
            gameObject.transform.position = new Vector3(tempPos.x, tempPos.y + m_val, tempPos.z);
            gameObject.transform.parent = other.gameObject.transform;
            m_Player = other.gameObject;
            if (m_Player.GetComponent<MaterialChanger>())
            {
                m_Player.GetComponent<MaterialChanger>().UpdateMatToBHMat();
            }
            if (m_Player.GetComponent<BombPass>())
            {
                m_Player.GetComponent<BombPass>().SetHoldingBomb(true, gameObject);
            }
        }
    }

    public void SetNewBombHolder(GameObject _newHolder)
    {
        print("Test");
        tempPos = _newHolder.transform.position;

        gameObject.transform.position = new Vector3(tempPos.x, tempPos.y + m_val, tempPos.z);
        gameObject.transform.parent = _newHolder.transform;
        m_Player = _newHolder;
        if (m_Player.GetComponent<MaterialChanger>())
        {
            m_Player.GetComponent<MaterialChanger>().UpdateMatToBHMat();
        }
        if (m_Player.GetComponent<BombPass>())
        {
            m_Player.GetComponent<BombPass>().SetHoldingBomb(true, gameObject);
        }
    }

    void TimeSystem()
    {
        
        m_Timer += Time.deltaTime;
        if (m_Timer > m_TimeLimit)
        {
            //put the bomb location under the car before trigger 
            gameObject.transform.position = new Vector3 (m_Player.transform.position.x, m_Player.transform.position.y - m_lowerVal, m_Player.transform.position.z + m_forwardVal);
            //triggers the explosion physics
            m_ExpPhy.trigger();
           //destroys the bomb
            Destroy(gameObject);
            m_initCol = false;
            //particles for explosion
            m_ParticleSpawner.SpawnParticle();
            //spawns in ner bomb
            m_BombSystem.SetBombSpawn(true);
        }
    }

}
