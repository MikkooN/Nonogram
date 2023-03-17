using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class TouchInput : MonoBehaviour
    {
        public static GameObject tappedSquare;
        private Button button;
        private Image image;
        private int totalNumberOfRights = StartLevel.totalNumberOfRights;
        public static WinCheck other;

        public void ButtonTapped()
        {
            tappedSquare = gameObject;
            image = tappedSquare.GetComponent<Image>();
            image.enabled = true;
            WinCheck.CheckIfWon();
            button = tappedSquare.GetComponentInParent<Button>();
            button.enabled = false;
        }
    }
}
