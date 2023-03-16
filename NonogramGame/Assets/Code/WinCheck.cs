using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class WinCheck : MonoBehaviour
    {
        public static GameObject tappedSquare;
        private static int totalNumberOfRights = StartLevel.totalNumberOfRights;
        private static int numberOfRights = 0;
        private static int health = 3;
        private static Image foodImage = StartLevel.foodImage;

        public static void CheckIfWon()
        {
            tappedSquare = Tap.tappedSquare;

            if (tappedSquare != null)
            {
                if (tappedSquare.tag == "Right")
                {
                    numberOfRights++;
                    Debug.Log(numberOfRights);
                    if (numberOfRights == totalNumberOfRights)
                    {
                        foodImage.enabled = true;
                        //Turn on win UI (next level button etc.)
                        //save the game at this point?

                    }
                }
                else if (tappedSquare.tag == "Wrong")
                {
                    health--;
                    Debug.Log(health);
                    if (health == 0)
                    {
                        //Turn on lose UI (try again button etc.)
                    }
                }
            }
        }
    }
}
