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
        public Sprite healthIcon;
        private Animator animator;

        public void LoseHealth(int health)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < health)
                {
                    //Keep the healthIcon for the hearts that haven't been lost
                    hearts[i].GetComponent<Image>().sprite = healthIcon;
                }
                else
                {
                    //If the player lost health, play burn animation
                    animator = hearts[i].GetComponentInChildren<Animator>();
                    animator.SetTrigger("Burn");
                }
            }
        }
    }
}
