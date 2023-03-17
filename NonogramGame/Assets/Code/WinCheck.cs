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
        private static GameObject loseUI;

        public static void CheckIfWon()
        {
            tappedSquare = TouchInput.tappedSquare;

            if (tappedSquare != null)
            {
                if (tappedSquare.tag == "Right")
                {
                    numberOfRights++;
                    Debug.Log(numberOfRights);
                    if (numberOfRights >= totalNumberOfRights)
                    {
                        //winUI = GameObject.FindGameObjectWithTag("WinUI");
                        //winUI.SetActive(true);
                        //Turn on win UI (next level button etc.)
                        //save the game at this point?

                    }
                }
                else if (tappedSquare.tag == "Wrong")
                {
                    health--;
                    Debug.Log(health);
                    if (health <= 0)
                    {
                        //loseUI = gameObject;
                        //loseUI.SetActive(true);
                        //Turn on lose UI (try again button etc.)
                    }
                }
            }
        }
    }
}
