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
            if (StartLevel.level >= 20)
            {
                LoadMainMenu();
            }
            else
            {
                //Add 1 to the level count, reset static variables and reload the level scene.
                StartLevel.level++;
                WinCheck.level++;
                SquareCheck.ResetLevel();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        
        public void LoadMainMenu()
        {
            //If the player has won the level, then add 1 to the level count
            //before resetting the level and exiting to menu.
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
            //Reset static variables manually and reload the level
            SquareCheck.ResetLevel();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
