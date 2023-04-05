using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
        [SerializeField] private Sprite[] sprites;

        [SerializeField] private Color disabledColor;
        private bool rowRevealed = false;
        private int index = 0;

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

            //Read the amount of rights & wrongs that the raycast hits
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
                        //If the numbers are on top of the game board,
                        //add a line break between each number
                        numberString = numberString + amount.ToString() + "\n";
                    }
                    else
                    {
                        //If the numbers are left of the game board,
                        //add a comma between each number
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

        //Check if the whole row/column has been played
        private void Update()
        {
            int buttonsDisabled = 0;

            foreach (GameObject right in rights)
            {
                if (right.GetComponentInParent<EventTrigger>().enabled == false)
                {
                    buttonsDisabled++;
                }
            }

            //Reveal the wrong buttons and turn the number text grey
            //when the whole row/column has been played
            if (buttonsDisabled == rights.Count && rights.Count > 0)
            {
                if (!rowRevealed)
                {
                    numberText.color = disabledColor;
                    foreach (GameObject wrong in wrongs)
                    {
                        if (wrong.GetComponent<Image>().enabled == false)
                        {
                            wrong.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length - 1)];
                            wrong.GetComponent<Image>().enabled = true;
                            wrong.GetComponentInParent<EventTrigger>().enabled = false;
                        }
                        index++;

                        if (index == wrongs.Count)
                        {
                            rowRevealed = true;
                        }
                    }
                }
            }
        }
    }
}
