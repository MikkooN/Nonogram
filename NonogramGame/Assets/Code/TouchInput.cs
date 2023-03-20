using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class TouchInput : MonoBehaviour
    {
        public GameObject tappedSquare;
        private Button button;
        private Image image;

        public void ButtonTapped()
        {
            //Turn on the image component in the button the player tapped
            tappedSquare = gameObject;
            image = tappedSquare.GetComponent<Image>();
            image.enabled = true;

            //Check if the tapped square was correct
            SquareCheck.CheckTag(tappedSquare);

            //Disable the button after one tap
            button = tappedSquare.GetComponentInParent<Button>();
            button.enabled = false;
        }
    }
}
