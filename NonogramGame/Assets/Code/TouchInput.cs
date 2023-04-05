using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Nonogram
{
    public class TouchInput : MonoBehaviour
    {
        private GameObject tappedSquare;
        private Image image;
        [SerializeField] private Sprite[] sprites;
        private EventTrigger trigger;


        public void ButtonTapped()
        {
            //Turn on the image component in the button the player tapped
            tappedSquare = gameObject;
            image = tappedSquare.GetComponent<Image>();
            image.sprite = sprites[Random.Range(0, sprites.Length - 1)];

            if (tappedSquare.gameObject.tag == "Wrong")
            {
                image.color = Color.red;
            }

            image.enabled = true;

            //Check if the tapped square was correct
            SquareCheck.CheckTag(tappedSquare);

            //Disable the button after one touch
            trigger = tappedSquare.GetComponentInParent<EventTrigger>();
            trigger.enabled = false;
        }
    }
}
