//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class Bomb_System : MonoBehaviour
//{
//    public enum BombState
//    {
//        BS_NULL = 0,
//        BS_SPAWN,
//        BS_LIVE,
//        BS_DESTROY
//    };

//    public GameObject m_Bomb;
//    public List<Vector3> m_Spawn;

//    private bool m_Drop = false;
//    private BombState m_BS;

//    private int m_SPNum;

//    // Use this for initialization
//    void Start()
//    {
//        m_SPNum = 0;
//        m_Drop = true;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        switch(m_BS)
//        {
//            case BombState.BS_NULL:
//                break;
//            case BombState.BS_SPAWN: Instantiate(m_Bomb, m_Spawn[m_SPNum], Quaternion.identity);
//                break;
//            case BombState.BS_LIVE:
//                break;
//            case BombState.BS_DESTROY:
//                break;
         
//        }

//        /* if (m_BS == BombState.BS_SPAWN)
//         {
//             m_Drop = false;
//           //  Instantiate(m_Bomb, ); // drop an instance of the bomb infront 
//         }*/
//      //  Debug();
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        print("collision");
//        print(m_SPNum);
//        if (m_BS == BombState.BS_NULL)
//        {
//            m_BS = BombState.BS_SPAWN;
//        }
//        m_SPNum++;
//    }

//    enum GetBombState()

//    void Debug()
//    {

//    }
//}


