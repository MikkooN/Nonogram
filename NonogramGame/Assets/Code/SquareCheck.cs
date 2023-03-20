using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class SquareCheck : MonoBehaviour
    {
        private static int totalNumberOfRights = StartLevel.totalNumberOfRights;
        private static int numberOfRights = 0;
        public static int health = 3;
        private static HealthManager healthUI;
        public static bool gameWon = false;
        public static bool gameLost = false;

        public static void CheckTag(GameObject tappedSquare)
        {
            if (tappedSquare != null)
            {
                if (tappedSquare.tag == "Right")
                {
                    numberOfRights++;
                    Debug.Log("Correct squares found: " + numberOfRights);
                    if (numberOfRights >= totalNumberOfRights)
                    {
                        gameWon = true;
                        //save the game at this point?

                    }
                }
                else if (tappedSquare.tag == "Wrong")
                {
                    health--;
                    Debug.Log("Health: " + health);
                    healthUI = GameObject.Find("Health").GetComponent<HealthManager>();
                    healthUI.LoseHealth(health);

                    if (health <= 0)
                    {
                        gameLost = true;
                    }
                }
            }
        }
    }
}
