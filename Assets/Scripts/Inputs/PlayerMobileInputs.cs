using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TritanTest.Inputs
{
    public class PlayerMobileInputs : PlayerInputs
    {
        public PlayerMobileInputs(bool enabled = true) : base(enabled)
        {
            controls.Player.Tap.performed += Tap;
        }

        private void Tap(InputAction.CallbackContext ctx)
        {
            Vector2 position = controls.Player.PrimaryPosition.ReadValue<Vector2>();
            InvokeMove(position);
        }
    }
}
