using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nonogram
{
    public class MainMenuQuit : MonoBehaviour
    {
        // Start is called before the first frame update
      public void QuitGame ()
      {
        Debug.Log ("Quit the game!");
        Application.Quit();
      }
    }
}
