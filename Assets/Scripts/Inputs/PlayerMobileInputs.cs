using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace TritanTest.Inputs
{
    public class PlayerMobileInputs : PlayerInputs
    {
        public PlayerMobileInputs(bool enabled = true) : base(enabled)
        {
            controls.Player.PrimaryPosition.performed += OnMoveFinger;
        }

        private void OnMoveFinger(InputAction.CallbackContext ctx)
        {
            if (IsPointerOverUIObject())
                return;

            // Tests
            //foreach (var touch in Touchscreen.current.touches)
            //{
            //    if (EventSystem.current.IsPointerOverGameObject(touch.touchId.valueSizeInBytes))
            //        return;
            //}

            //foreach (var touch in Input.touches)
            //{
            //    if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            //        return;
            //}

            Vector2 position = ctx.ReadValue<Vector2>();
            InvokeMove(position);
        }

        private bool IsPointerOverUIObject()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
    }
}
