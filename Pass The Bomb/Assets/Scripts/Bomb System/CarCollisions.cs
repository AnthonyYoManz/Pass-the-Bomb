using UnityEngine;
using System.Collections;

public class CarCollisions : MonoBehaviour
{
    private GameObject m_BombSystemObject;
    private Bomb_System m_BombSystem;

   void Start()
    {
        m_BombSystemObject = GameObject.FindGameObjectWithTag("BombSystem");
        m_BombSystem = m_BombSystemObject.GetComponent<Bomb_System>();
    }
    void OnTriggerEnter(Collider car)
    {

        m_BombSystem.SetSpawnNum();
        
    }
}
