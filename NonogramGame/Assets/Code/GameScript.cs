using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nonogram
{
    public class GameScript : MonoBehaviour
    {
        private int totalNumberOfRights;
        private int numberOfRights = 0;
        private int health = 3;
        private bool gameFinished = false;
        private GameObject tappedSquare;
        private GameObject foodImage;
        private SpriteRenderer squareRenderer;
        private SpriteRenderer foodRenderer;

        void Start()
        {
            tappedSquare = TouchInput.tappedSquare;
            foodImage = GameObject.FindGameObjectWithTag("Food");
            totalNumberOfRights = GameObject.FindGameObjectsWithTag("Right").Length;
            Debug.Log(totalNumberOfRights);

            while (gameFinished == false)
            {
                squareRenderer = tappedSquare.GetComponent<SpriteRenderer>();
                squareRenderer.enabled = true;

                if (tappedSquare.tag == "Right")
                {
                    numberOfRights++;
                    if (numberOfRights == totalNumberOfRights)
                    {
                        gameFinished = true;
                        foodRenderer = foodImage.GetComponent<SpriteRenderer>();
                        foodRenderer.enabled = true;
                        //Turn on win UI (next level button etc.)
                        //save the game at this point?

                    }
                }
                else if (tappedSquare.tag == "Wrong")
                {
                    health--;
                    if (health == 0)
                    {
                        gameFinished = true;
                        //Turn on lose UI (try again button etc.)
                    }
                }
            }
        }
    }
}