using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

namespace Nonogram
{
    public class SetLocale : MonoBehaviour
    {
        [SerializeField] private Locale locale;

        public void Apply()
        {
            //Apply the chosen locale and reload the menu scene
            LocalizationSettings.SelectedLocale = locale;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Locale set to " + locale.ToString());
        }
    }
}
