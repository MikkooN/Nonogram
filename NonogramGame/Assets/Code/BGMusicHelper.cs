using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nonogram
{
    public class BGMusicHelper : MonoBehaviour
    {
        static BGMusicHelper instance;

        void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }

            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}
