using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bomb_System : MonoBehaviour
{
  

    public GameObject m_Bomb;
    public List<GameObject> m_SpawnPoints;

    public bool m_SpawnBomb = false; //
    
    public int m_SPNum;

   
    void Start()
    {
        m_SPNum = 0;
        m_SpawnBomb = true;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (m_SpawnBomb)
        {
            
            m_SpawnBomb = false;
            BombSpawn();
        }
        if(m_SPNum >= m_SpawnPoints.Count)
        {
            m_SPNum = 0;
        }

    }
    void BombSpawn()
    {
        Instantiate(m_Bomb, m_SpawnPoints[m_SPNum].transform.position, Quaternion.identity);
    }

    public void SetBombSpawn(bool _set)
    {
        m_SpawnBomb = _set;
    }

    public void SetSpawnNum()
    {
        print(m_SPNum);
        m_SPNum++;
        //SetBombSpawn(true);
    }

}


