using UnityEngine;
using UnityEngine.InputSystem;

namespace TritanTest.Inputs 
{
    public class PlayerPCInputs : PlayerInputs 
    {
        private bool leftPressed;

        public PlayerPCInputs(bool enabled = true) : base(enabled) 
        {
            controls.Player.MousePosition.performed += OnMoveMouse;
            controls.Player.LeftClick.started += OnLeftClickPressed;
            controls.Player.LeftClick.canceled += OnLeftClickRelease;
        }

        private void OnMoveMouse(InputAction.CallbackContext ctx) 
        {
            if (leftPressed)
            {
                Vector2 mousePosition = ctx.ReadValue<Vector2>();
                InvokeMove(mousePosition);
            }
        }

        private void OnLeftClickPressed(InputAction.CallbackContext ctx)
        {
            leftPressed = true;

            Vector2 mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();
            InvokeMove(mousePosition);
        }

        private void OnLeftClickRelease(InputAction.CallbackContext ctx)
        {
            leftPressed = false;
        }
    }
}
