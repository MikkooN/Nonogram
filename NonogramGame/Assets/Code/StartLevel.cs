using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class StartLevel : MonoBehaviour
    {
        public static int totalNumberOfRights;
        public static GameObject food;
        public static Image foodImage;

        void Start()
        {
            food = GameObject.FindGameObjectWithTag("Food");
            foodImage = food.GetComponent<Image>();
            totalNumberOfRights = GameObject.FindGameObjectsWithTag("Right").Length;
            Debug.Log(totalNumberOfRights);
        }
    }
}