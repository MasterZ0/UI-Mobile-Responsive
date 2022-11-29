using UnityEngine;
using UnityEngine.InputSystem;

namespace TritanTest.Inputs 
{
    public class PlayerPCInputs : PlayerInputs 
    {
        public PlayerPCInputs(bool enabled = true) : base(enabled) 
        {
            controls.Player.LeftClick.started += LeftClickStart;
        }

        private void LeftClickStart(InputAction.CallbackContext ctx) 
        {
            Vector2 position = controls.Player.MousePosition.ReadValue<Vector2>();
            InvokeMove(position);
        }
    }
}
