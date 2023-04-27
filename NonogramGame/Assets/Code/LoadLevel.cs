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
        /*public static void LoadNextLevel()
        {
            int level = LoadUniversalScene.selectedLevel + 1;
            SquareCheck.ResetLevel();
            LoadUniversalScene.UniversalSceneOpen(level);
        }*/
        
        public static void LoadMainMenu()
        {
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
