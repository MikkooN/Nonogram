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
        private string numberString;

        void Start()
        {
            StartCoroutine(Wait());
        }

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.1f);
            GetNumbers();
        }

        public void GetNumbers()
        {
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

            foreach (RaycastHit2D hit in hits)
            {
                if (hit.collider.gameObject.tag == "Right")
                {
                    amount++;
                }
                else if (hit.collider.gameObject.tag == "Wrong" && amount > 0)
                {
                    numberString = numberString + amount.ToString();
                }
            }
            numberText.text = numberString;
            numberText.text = amount.ToString();
        }
    }
}
