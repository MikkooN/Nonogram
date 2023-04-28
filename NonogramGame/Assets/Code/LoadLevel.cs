using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Nonogram
{
    public class LoadLevel : MonoBehaviour
    {
        private bool gameWon;


        public void LoadNextLevel()
        {
            StartLevel.level++;
            WinCheck.level++;
            SquareCheck.ResetLevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        public void LoadMainMenu()
        {
            gameWon = SquareCheck.gameWon;
            if (gameWon == true)
            {
                StartLevel.level++;
                WinCheck.level++;
            }

            SquareCheck.ResetLevel(); 
            SceneManager.LoadScene("MainMenu");
        }
        
        public void QuitGame ()
        {
            Debug.Log ("Quit the game!");
            Application.Quit();
        }
        
        public void ReplayLevel ()
        {
            SquareCheck.ResetLevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
