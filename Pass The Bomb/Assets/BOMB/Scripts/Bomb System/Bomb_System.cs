using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bomb_System : MonoBehaviour
{
  

    public GameObject m_Bomb;
    public GameObject m_SpawnPoint;
    private Transform m_NewSpawnPoint;
   
    void Start()
    {
        GetCarSpawnPoint();
        BombSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void BombSpawn()
    {
        Instantiate(m_Bomb, m_SpawnPoint.transform.position, Quaternion.identity);
    }

    void GetCarSpawnPoint()
    {
        //Find where the cars are being spawned
        Transform t_CarSpawnPoint;
        t_CarSpawnPoint = m_SpawnPoint.transform;
        SetUpSpawnPoint(t_CarSpawnPoint.transform);
    }

    void SetUpSpawnPoint(Transform _CarSpawnPoint)
    {
        m_NewSpawnPoint = _CarSpawnPoint;
    }
}


