using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Nonogram
{
    public class LoadLevelSelect : MonoBehaviour
    {
        int levelsUnlocked;

        public Button[] buttons;
        

        void Start()
        {
            levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }

            for (int i = 0; i < levelsUnlocked; i++)
            {
                buttons[i].interactable = true;
            }
        
        }

        public void levelUnlock()
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex;

            if(currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
            {
                PlayerPrefs.SetInt("levelsUnlocked", currentLevel +1);
            }

            Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelsUnlocked") + "UNLOCKED");
        }

        public void LevelSelect(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }
        
        public static void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        
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
