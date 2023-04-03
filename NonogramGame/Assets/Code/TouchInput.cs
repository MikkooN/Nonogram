using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Nonogram
{
    public class TouchInput : MonoBehaviour
    {
        private GameObject tappedSquare;
        private Image image;
        [SerializeField] private Sprite[] sprites;
        private Button button;


        public void ButtonTapped()
        {
            //Turn on the image component in the button the player tapped
            tappedSquare = gameObject;
            image = tappedSquare.GetComponent<Image>();
            image.sprite = sprites[Random.Range(0, sprites.Length - 1)];
            image.enabled = true;

            //Check if the tapped square was correct
            SquareCheck.CheckTag(tappedSquare);

            //Disable the button after one touch
            button = tappedSquare.GetComponentInParent<Button>();
            button.enabled = false;
        }
    }
}
