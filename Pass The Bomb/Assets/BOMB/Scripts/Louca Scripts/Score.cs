using UnityEngine;
using System.Collections;

namespace GCSharp
{
    public class Score : MonoBehaviour
    {

        [SerializeField]
        private int score;


        // Use this for initialization
        void Start()
        {
            score = 0;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddScore()
        {
            score++;
        }

        public void ResetScore()
        {
            score = 0;
        }
    }
}