using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Nonogram
{
    public class Numbers : MonoBehaviour
    {
        private int amount = 0;
        private RaycastHit2D[] hits;
        [SerializeField] private TMP_Text numberText;
        private string numberString = "";

        void Start()
        {
            StartCoroutine(Wait());
        }

        IEnumerator Wait()
        {
            //Wait a moment so the gameboard gets built
            yield return new WaitForSeconds(1f);
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
                }
                else if (hit.collider.gameObject.tag == "Wrong" && amount > 0)
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
                
                /*if (hit.Equals(hits.Length - 1))
                {
                    numberString = numberString + amount.ToString();
                }*/
            }

            /*for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.tag == "Right")
                {
                    amount++;
                }
                else if (hits[i].collider.gameObject.tag == "Wrong" && amount > 0)
                {
                    numberString = numberString + amount.ToString() + ",";
                    amount = 0;
                }
                else if (i == hits.Length - 1)
                {
                    numberString = numberString + amount.ToString();
                }
            }*/

            /*if (numberString != "")
            {
                numberText.text = numberString.TrimEnd(',');
            }
            else
            {
                numberText.text = amount.ToString();
            }*/

            if (amount == 0)
            {
                numberText.text = numberString.TrimEnd(',');
            }
            else
            {
                numberText.text = (numberString + amount.ToString()).TrimEnd(',');
            }
        }
    }
}
