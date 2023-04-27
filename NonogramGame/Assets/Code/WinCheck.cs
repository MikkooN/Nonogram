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
        [SerializeField] private Sprite[] foodImages;
        [SerializeField] private TMP_Text foodName;
        int level = LoadUniversalScene.selectedLevel;

        void Update()
        {
            gameWon = SquareCheck.gameWon;
            gameLost = SquareCheck.gameLost;

            if (gameWon == true)
            {
                //If the player won, turn on win UI and
                //get the correct food image & name
                winUI.SetActive(true);
                winImage.sprite = foodImages[level - 1];
                foodName.text = foodImages[level - 1].name;

                PlayerPrefs.SetInt("levelsUnlocked", level + 1);
            }

            if (gameLost == true)
            {
                loseUI.SetActive(true);

                //Emma messing with stuff: 
                AudioSource audio = loseUI.GetComponent<AudioSource>();
                if (audio != null )
                {
                    audio.Play();
                }
            }
        }
    }
}
