using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        [SerializeField] private TMP_Text foodName;

        void Update()
        {
            gameWon = SquareCheck.gameWon;
            gameLost = SquareCheck.gameLost;

            if (gameWon == true)
            {
                winUI.SetActive(true);
                winImage.sprite = foodImage;
                foodName.text = foodImage.name;
            }

            if (gameLost == true)
            {
                loseUI.SetActive(true);
            }
        }
    }
}
