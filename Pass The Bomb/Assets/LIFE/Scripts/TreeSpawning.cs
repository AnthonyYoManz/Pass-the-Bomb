using UnityEngine;
using System.Collections;

namespace GCSharp
{
    public class TreeSpawning : MonoBehaviour
    {
        // public Transform[] children;
        public GameObject tree;
        public GameObject tree2;
        public GameObject sign;
        public GameObject sign2;
        public GameObject lamp;
        public GameObject rock;

        public Vector3 rockShift;
        public Vector3 treeShift;
        public Vector3 lampShift;
        public Vector3 signShift;

        void Start()
        {

            foreach (Transform child in transform)
            {
                switch (child.gameObject.name)
                {
                    case "SSpawn":
                        Instantiate(tree, child.position += treeShift, child.rotation);
                        break;
                    case "CSpawn":
                        Instantiate(tree2, child.position += treeShift, child.rotation);
                        break;
                    case "streetSign":
                        if (Random.Range(0f, 1f) >= 0.5f)
                        {
                            Instantiate(sign, child.position += signShift, child.rotation);
                        }
                        else
                        {
                            Instantiate(sign2, child.position += signShift, child.rotation);
                        }
                        break;
                    case "lamp":
                        Instantiate(lamp, child.position += lampShift, child.rotation);
                        break;
                    case "rock":
                        Instantiate(rock, child.position += rockShift, child.rotation);
                        break;
                    default:
                        break;
                }
            }
        }


        void Update()
        {

        }
    }
}