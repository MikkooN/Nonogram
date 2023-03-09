using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nonogram
{
    public class TouchInput : MonoBehaviour
    {
        public static GameObject tappedSquare;

        void Update()
        {
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit raycastHit;

                if (Physics.Raycast(raycast, out raycastHit))
                {
                    tappedSquare = raycastHit.collider.gameObject;
                }
            }
        }
    }
}
