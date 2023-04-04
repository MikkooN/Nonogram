using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class StartLevel : MonoBehaviour
    {
        int level = LoadUniversalScene.selectedLevel;
        [SerializeField] private Texture2D[] foodImages;
        private int boardSize;
        private Color[] pixels;

        private Transform gameBoard;
        [SerializeField] private GameObject gameBoard5x5;
        [SerializeField] private GameObject gameBoard10x10;
        [SerializeField] private GameObject gameBoard15x15;
        [SerializeField] private GameObject right;
        [SerializeField] private GameObject wrong;

        private Transform numbersLeft;
        private Transform numbersTop;
        [SerializeField] private GameObject numberLeft;
        [SerializeField] private GameObject numberTop;

        public static int totalNumberOfRights;

        private void Awake()
        {
            totalNumberOfRights = 0;
        }

        void Start()
        {
            //Read the colors and the size of the gameboard from the B&W image
            pixels = foodImages[level - 1].GetPixels();
            boardSize = foodImages[level - 1].width;

            //Choose & activate the correct board depending on the size of the image
            if (boardSize == 5)
            {
                numbersLeft = gameBoard5x5.transform.GetChild(0);
                numbersTop = gameBoard5x5.transform.GetChild(1);
                gameBoard = gameBoard5x5.transform.GetChild(2);
                gameBoard5x5.SetActive(true);
            }
            else if (boardSize == 10)
            {
                numbersLeft = gameBoard10x10.transform.GetChild(0);
                numbersTop = gameBoard10x10.transform.GetChild(1);
                gameBoard = gameBoard10x10.transform.GetChild(2);
                gameBoard10x10.SetActive(true);
            }
            else
            {
                numbersLeft = gameBoard15x15.transform.GetChild(0);
                numbersTop = gameBoard15x15.transform.GetChild(1);
                gameBoard = gameBoard15x15.transform.GetChild(2);
                gameBoard15x15.SetActive(true);
            }

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

            //Add the numbers to the sides of the board
            for (int i = 0; i < boardSize; i++)
            {
                Instantiate(numberLeft, numbersLeft);
                Instantiate(numberTop, numbersTop);
            }

            //Find the total amount of correct squares in the level
            totalNumberOfRights = GameObject.FindGameObjectsWithTag("Right").Length;
            Debug.Log("Total number of rights: " + totalNumberOfRights);
        }
    }
}