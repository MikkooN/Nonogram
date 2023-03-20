using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nonogram
{
    public class WinCheck : MonoBehaviour
    {
        private bool gameWon;
        private bool gameLost;
        public GameObject winUI;
        public GameObject loseUI;

        void Update()
        {
            gameWon = SquareCheck.gameWon;
            gameLost = SquareCheck.gameLost;

            if (gameWon == true)
            {
                winUI.SetActive(true);
            }

            if (gameLost == true)
            {
                loseUI.SetActive(true);
            }
        }
    }
}
