using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class WinCheck : MonoBehaviour
    {
        private bool gameWon;
        private bool gameLost;
        public GameObject winUI;
        public GameObject loseUI;

        [SerializeField] private Image winImage;
        [SerializeField] private Sprite foodImage;

        void Update()
        {
            gameWon = SquareCheck.gameWon;
            gameLost = SquareCheck.gameLost;

            if (gameWon == true)
            {
                winUI.SetActive(true);
                winImage.sprite = foodImage;
            }

            if (gameLost == true)
            {
                loseUI.SetActive(true);
            }
        }
    }
}
