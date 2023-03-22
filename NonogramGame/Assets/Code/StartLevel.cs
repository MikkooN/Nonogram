using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Nonogram
{
    public class StartLevel : MonoBehaviour
    {
        [SerializeField] private Texture2D[] foodImages;
        private Texture2D foodImage;
        private Color[] pixels;
        [SerializeField] private Transform board;
        [SerializeField] private GameObject right;
        [SerializeField] private GameObject wrong;
        [SerializeField] private Transform numbersLeft;
        [SerializeField] private Transform numbersTop;
        [SerializeField] private GameObject number;
        private int boardSize;
        private int amountOfRights = 0;
        private TMP_Text amountText;

        public static int totalNumberOfRights;

        void Start()
        {
            //Read the colors of the B&W image, reverse the array
            foodImage = foodImages[0];
            pixels = foodImage.GetPixels();
            System.Array.Reverse(pixels);
            boardSize = foodImage.width;
            amountText = number.GetComponentInChildren<TextMeshPro>();
            Debug.Log("Board size: " + boardSize);

            //Build the gameboard based on the B&W pixels
            foreach (Color color in pixels)
            {
                if (color.Equals(Color.black))
                {
                    Instantiate(right, board);
                }
                else
                {
                    Instantiate(wrong, board);
                }
            }

            //Assign the numbers on the sides of the board
            /*for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (pixels[j].Equals(Color.black))
                    {
                        amountOfRights++;
                    }

                    amountText.text = amountOfRights.ToString();
                    Instantiate(number, numbersLeft);
                }
            }*/

            //Find the total amount of correct squares in the level
            totalNumberOfRights = GameObject.FindGameObjectsWithTag("Right").Length;
            Debug.Log("Total number of rights: " + totalNumberOfRights);
        }
    }
}