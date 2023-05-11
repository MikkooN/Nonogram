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
        public AudioSource burnAudio;

        public void LoseHealth(int health)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i > health - 1)
                {
                    //If the player lost health, play burn animation
                    animator = hearts[i].GetComponentInChildren<Animator>();
                    animator.SetTrigger("Burn");
                    burnAudio.Play();
                }
            }
        }
    }
}
