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
        public static int selectedLevel;
        [SerializeField] private int level;
        [SerializeField] private TMP_Text levelText;

        void Start()
        {
            levelText.text = level.ToString();
        }

        public void UniversalSceneOpen()
        {
            selectedLevel = level;
            SceneManager.LoadScene("DefaultScene");
        }
    }
}
