using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nonogram
{
    public class Saving : MonoBehaviour
    {
        public void DeleteSaveData()
        {
            PlayerPrefs.DeleteKey("levelsUnlocked");
        }
    }
}
