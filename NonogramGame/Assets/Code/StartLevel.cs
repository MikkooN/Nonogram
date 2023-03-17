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
            totalNumberOfRights = GameObject.FindGameObjectsWithTag("Right").Length;
            Debug.Log(totalNumberOfRights);
        }
    }
}