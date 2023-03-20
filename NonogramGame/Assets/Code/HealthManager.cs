using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class HealthManager : MonoBehaviour
    {
        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;

        public void LoseHealth(int health)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;
                } else
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        }
    }
}
