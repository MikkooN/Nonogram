using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class Tap : MonoBehaviour
    {
        public static GameObject tappedSquare;
        private Image image;
        private int totalNumberOfRights = StartLevel.totalNumberOfRights;
        public static WinCheck other;

        public void TappedSquare()
        {
            tappedSquare = gameObject;
            image = tappedSquare.GetComponent<Image>();
            image.enabled = true;
            WinCheck.CheckIfWon();
        }
    }
}
