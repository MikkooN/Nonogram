using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Nonogram
{
    public class LoadUniversalScene : MonoBehaviour
    {
        [SerializeField] private int level;
        [SerializeField] private TMP_Text levelText;

        void Start()
        {
            //Turn the level number to text to be displayed on the level button
            levelText.text = "Level " + level.ToString();
        }

        public void UniversalSceneOpen()
        {
            //Open the universal level scene with the level number
            SceneManager.LoadScene("DefaultScene");
            StartLevel.level = level;
            WinCheck.level = level;
        }
    }
}
