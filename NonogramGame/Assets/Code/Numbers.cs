using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Nonogram
{
    public class Numbers : MonoBehaviour
    {
        private int amount = 0;
        private RaycastHit2D[] hits;
        [SerializeField] private TMP_Text numberText;
        private string numberString = "";

        private List<GameObject> rights = new List<GameObject>();
        private List<GameObject> wrongs = new List<GameObject>();

        [SerializeField] private Color disabledColor;

        void Start()
        {
            StartCoroutine(Wait());
        }

        IEnumerator Wait()
        {
            //Wait a moment so the gameboard gets built
            yield return new WaitForSeconds(0.1f);
            GetNumbers();
        }

        public void GetNumbers()
        {
            //Shoot a raycast either down or to the right
            if (gameObject.tag == "Left")
            {
                Debug.DrawRay(transform.position, transform.right * 7, Color.black);
                hits = Physics2D.RaycastAll(transform.position, transform.right * 7);
            }
            else if (gameObject.tag == "Top")
            {
                Debug.DrawRay(transform.position, transform.up * -7, Color.black);
                hits = Physics2D.RaycastAll(transform.position, transform.up * -7);
            }

            //Read the amount of rights that the raycast hits
            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.gameObject.tag == "Right")
                {
                    amount++;
                    //Add the rights to their own list
                    rights.Add(hit.collider.gameObject); 
                }
                else if (hit.collider.gameObject.tag != "Right")
                {
                    //Add the wrongs to their own list
                    wrongs.Add(hit.collider.gameObject);
                }

                //Format the text depending on the orientation
                if (hit.collider.gameObject.tag == "Wrong" && amount > 0)
                {
                    if (gameObject.tag == "Top")
                    {
                        numberString = numberString + amount.ToString() + "\n";
                    }
                    else
                    {
                        numberString = numberString + amount.ToString() + ",";
                    }
                    amount = 0;
                }
            }

            //Put the number of rights on the gameboard
            if (amount == 0)
            {
                numberText.text = numberString.TrimEnd(',');
            }
            else
            {
                numberText.text = (numberString + amount.ToString()).TrimEnd(',');
            }

            //Change font size depending on the size of the board
            if (hits.Length == 10)
            {
                numberText.fontSize = 35;
            }
            else if (hits.Length == 15)
            {
                numberText.fontSize = 30;
            }
        }

        private void Update()
        {
            int buttonsDisabled = 0;

            foreach (GameObject right in rights)
            {
                if (right.GetComponentInParent<Button>().enabled == false)
                {
                    buttonsDisabled++;
                }
            }

            //Reveal the wrong buttons and turn the number text grey
            //when the whole row has been played
            if (buttonsDisabled == rights.Count && rights.Count > 0)
            {
                numberText.color = disabledColor;
                foreach (GameObject wrong in wrongs)
                {
                    wrong.GetComponent<Image>().enabled = true;
                    wrong.GetComponentInParent<Button>().enabled = false;
                }
            }
        }
    }
}
