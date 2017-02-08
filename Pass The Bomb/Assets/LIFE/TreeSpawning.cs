using UnityEngine;
using System.Collections;

public class TreeSpawning : MonoBehaviour
{
   // public Transform[] children;
    public GameObject tree;
    public GameObject tree2;
    void Start()
    {

        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "SSpawn")
            {
                Instantiate(tree, child.position, child.rotation);
            }
            else if (child.gameObject.name == "CSpawn")
            {
                Instantiate(tree2, child.position, child.rotation);
            }

            //child is your child transform
        }
    }


    void Update()
    {

    }
}
