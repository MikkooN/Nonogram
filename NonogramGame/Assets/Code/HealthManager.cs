using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class HealthManager : MonoBehaviour
    {
        public GameObject[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;
        private ParticleSystem burn;

        public void LoseHealth(int health)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    hearts[i].GetComponent<Image>().sprite = fullHeart;
                }
                else
                {
                    hearts[i].GetComponent<Image>().sprite = emptyHeart;
                    burn = hearts[i].GetComponentInChildren<ParticleSystem>();
                    burn.Play();

                    RomeveElement(ref hearts, i);
                }
            }
        }

        private void RomeveElement(ref GameObject[] hearts, int index)
        {
            for (int i = index; i < hearts.Length - 1; i++)
            {
                hearts[i] = hearts[i + 1];
            }
            Array.Resize(ref hearts, hearts.Length - 1);
        }
    }
}
