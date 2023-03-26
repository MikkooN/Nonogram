using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class StartLevel : MonoBehaviour
    {
        [SerializeField] private Texture2D foodImage;
        private int boardSize;
        private Color[] pixels;

        [SerializeField] private Transform gameBoard;
        [SerializeField] private GameObject right;
        [SerializeField] private GameObject wrong;

        [SerializeField] private Transform numbersLeft;
        [SerializeField] private Transform numbersTop;
        [SerializeField] private GameObject numberLeft;
        [SerializeField] private GameObject numberTop;
        //private List<GameObject> listOfNumbersLeft = new List<GameObject>();

        public static int totalNumberOfRights;

        void Start()
        {
            //Read the colors of the B&W image
            pixels = foodImage.GetPixels();
            boardSize = foodImage.width;

            //Build the game board according to the B&W pixels
            foreach (Color color in pixels)
            {
                if (color.Equals(Color.black))
                {
                    Instantiate(right, gameBoard);
                }
                else
                {
                    Instantiate(wrong, gameBoard);
                }
            }

            //Add numbers to the sides of the board
            for (int i = 0; i < boardSize; i++)
            {
                Instantiate(numberLeft, numbersLeft);
                Instantiate(numberTop, numbersTop);
                //listOfNumbersLeft.Add(numberObject);
            }

            /*foreach (GameObject numberObject in listOfNumbersLeft)
            {
                numberObject.GetComponent<Numbers>().GetNumbers();
            }*/

            //Find the total amount of correct squares in the level
            totalNumberOfRights = GameObject.FindGameObjectsWithTag("Right").Length;
            Debug.Log("Total number of rights: " + totalNumberOfRights);
        }
    }
}