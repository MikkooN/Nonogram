using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;

namespace Nonogram
{
    public class LoadUniversalScene : MonoBehaviour
    {
        [SerializeField] private int level;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private LocalizedString localizedLevel;

        void Start()
        {
            //Turn the level number to text to be displayed on the level button
            levelText.text = String.Format(localizedLevel.GetLocalizedString(), level);
        }

        private void OnEnable()
        {
            LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
        }

        private void OnDisable()
        {
            LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
        }

        private void OnLocaleChanged(Locale obj)
        {
            SetLevelText();
        }

        private void SetLevelText()
        {
            //Turn the level number to text to be displayed on the level button
            levelText.text = String.Format(localizedLevel.GetLocalizedString(), level);
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
