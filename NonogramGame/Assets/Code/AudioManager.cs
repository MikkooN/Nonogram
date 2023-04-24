using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nonogram
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource audio;

        public void playButtons()
        {
            audio.Play();
        }

        
        
    }
}
