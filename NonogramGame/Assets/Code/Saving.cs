using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Nonogram
{
    public class Saving : MonoBehaviour
    {
        int levelsUnlocked;
        [SerializeField] private Button[] buttons;
        [SerializeField] private Sprite[] foodImages;
        Image foodImage;
        private TMP_Text foodName;
        private GameObject empty;
        private GameObject image;

        void Start()
        {
            levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
                empty = buttons[i].transform.GetChild(2).gameObject;
                empty.SetActive(true);
            }

            for (int i = 0; i < levelsUnlocked; i++)
            {
                buttons[i].interactable = true;

                if (i < levelsUnlocked - 1)
                {
                    empty = buttons[i].transform.GetChild(2).gameObject;
                    empty.SetActive(false);

                    image = buttons[i].transform.GetChild(3).gameObject;
                    image.SetActive(true);
                    foodImage = buttons[i].transform.GetChild(3).GetComponent<Image>();
                    foodImage.sprite = foodImages[i];
                    foodName = buttons[i].transform.GetChild(1).GetComponent<TMP_Text>();
                    foodName.text = foodImages[i].name;
                }
            }
        }

        public void DeleteSaveData()
        {
            PlayerPrefs.DeleteKey("levelsUnlocked");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
