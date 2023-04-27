using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class SquareCheck : MonoBehaviour
    {
        private static int totalNumberOfRights;
        private static int numberOfRights = 0;
        public static int health = 3;
        private static HealthManager healthUI;
        public static bool gameWon = false;
        public static bool gameLost = false;

        public static void GetNumberOfRights()
        {
            //Get the number of rights in the level from the StartLevel script
            totalNumberOfRights = StartLevel.totalNumberOfRights;
        }

        public static void CheckTag(GameObject tappedSquare)
        {
            if (tappedSquare != null)
            {
                if (tappedSquare.tag == "Right")
                {
                    //If the player taps a right square, number of rights goes up
                    //until all the rights have been found
                    numberOfRights++;
                    Debug.Log("Correct squares found: " + numberOfRights);

                    if (numberOfRights == totalNumberOfRights)
                    {
                        gameWon = true;
                    }
                }
                else if (tappedSquare.tag == "Wrong")
                {
                    //If the player taps a wrong square,
                    //lose health and call the health manager
                    health--;
                    Debug.Log("Health: " + health);
                    healthUI = GameObject.Find("Health").GetComponent<HealthManager>();
                    healthUI.LoseHealth(health);

                    if (health == 0)
                    {
                        gameLost = true;
                    }
                }
            }
        }

        public static void ResetLevel()
        {
            //Reset static variables before leaving the level
            numberOfRights = 0;
            health = 3;
            gameLost = false;
            gameWon = false;
        }
    }
}
