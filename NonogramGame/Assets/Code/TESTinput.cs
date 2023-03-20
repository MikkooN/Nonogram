using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Nonogram
{
    public class TESTinput : MonoBehaviour
    {
        public static GameObject tappedSquare;

        private PlayerInput playerInput;
        private InputAction tap;
        private Vector3 worldTouchPosition;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            tap = playerInput.actions.FindAction("Tap");
        }

        private void OnEnable()
        {
            tap.performed += Tapped;
        }

        private void OnDisable()
        {
            tap.performed -= Tapped;
        }

        private void Tapped(InputAction.CallbackContext context)
        {
            Vector3 tapPosition = Camera.main.ScreenToWorldPoint(tap.ReadValue<Vector2>());

            /*Vector2 touchPosition = context.ReadValue<Vector2>();
            Vector3 screenCoordinate = touchPosition;
            this.worldTouchPosition = Camera.main.ScreenToWorldPoint(screenCoordinate);*/

            Debug.Log(tapPosition);
        }


        /*void Update()
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
        }*/
    }
}
