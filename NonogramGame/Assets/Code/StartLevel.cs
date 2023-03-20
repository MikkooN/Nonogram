using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class StartLevel : MonoBehaviour
    {
        public static int totalNumberOfRights;

        void Start()
        {
            //Find the total amount of correct squares in the level
            totalNumberOfRights = GameObject.FindGameObjectsWithTag("Right").Length;
            Debug.Log("Total number of rights: " + totalNumberOfRights);
        }
    }
}