using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nonogram
{
    public class LoadLevelSelect : MonoBehaviour
    {
       public static void LoadNextLevel()
       {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
       }

       public static void LoadMainMenu()
       {
            SceneManager.LoadScene("MainMenu");
       }

       public void QuitGame ()
      {
        Debug.Log ("Quit the game!");
        Application.Quit();
      }

      public void ReplayLevel ()
      {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
      }
    }
}
