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

            //Disable all level buttons
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
                empty = buttons[i].transform.GetChild(3).gameObject;
                empty.SetActive(true);
            }

            //Enable level buttons for all the unlocked levels
            //and reveal the pictures for all the cleared levels
            for (int i = 0; i < levelsUnlocked; i++)
            {
                buttons[i].interactable = true;

                if (i < levelsUnlocked - 1)
                {
                    empty = buttons[i].transform.GetChild(3).gameObject;
                    empty.SetActive(false);

                    image = buttons[i].transform.GetChild(4).gameObject;
                    image.SetActive(true);
                    foodImage = buttons[i].transform.GetChild(4).GetComponent<Image>();
                    foodImage.sprite = foodImages[i];
                    foodName = buttons[i].transform.GetChild(2).GetComponent<TMP_Text>();
                    foodName.text = foodImages[i].name;
                }
            }
        }

        public void DeleteSaveData()
        {
            //Delete levelsunlocked from playerprefs and start
            //the game from the beginning.
            PlayerPrefs.DeleteKey("levelsUnlocked");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
