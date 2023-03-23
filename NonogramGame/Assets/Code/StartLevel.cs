using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Nonogram
{
    public class StartLevel : MonoBehaviour
    {
        [SerializeField] private Texture2D foodImage;
        private Color[] pixels;

        [SerializeField] private Transform gameBoard;
        [SerializeField] private GameObject right;
        [SerializeField] private GameObject wrong;

        public static int totalNumberOfRights;

        void Start()
        {
            //Read the colors of the B&W image
            pixels = foodImage.GetPixels();

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


            //Find the total amount of correct squares in the level
            totalNumberOfRights = GameObject.FindGameObjectsWithTag("Right").Length;
            Debug.Log("Total number of rights: " + totalNumberOfRights);
        }
    }
}