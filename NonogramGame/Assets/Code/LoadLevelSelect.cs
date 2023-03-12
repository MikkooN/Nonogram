using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Nonogram
{
    public class LoadLevelSelect : MonoBehaviour
    {
       public static void LoadLevel()
       {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
       }
    }
}
