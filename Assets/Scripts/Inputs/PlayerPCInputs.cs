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
            controls.Player.LeftClick.started += ctx => leftPressed = true;
            controls.Player.LeftClick.canceled += ctx => leftPressed = false;
        }

        private void OnMoveMouse(InputAction.CallbackContext ctx) 
        {
            if (leftPressed)
            {
                Vector2 mousePosition = controls.Player.MousePosition.ReadValue<Vector2>();
                InvokeMove(mousePosition);
            }
        }
    }
}
