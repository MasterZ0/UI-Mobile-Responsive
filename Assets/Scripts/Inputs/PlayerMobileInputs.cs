using UnityEngine;
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
            Vector2 position = ctx.ReadValue<Vector2>();
            InvokeMove(position);
        }
    }
}
