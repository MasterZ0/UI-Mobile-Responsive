using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TritanTest
{
    public class UIInputs : BaseInput
    {
        public event Action OnSubmit = delegate { };
        public event Action OnCancel = delegate { };
        public event Action OnLeftTab = delegate { };
        public event Action OnRightTab = delegate { };
        public event Action<Vector2> OnMove = delegate { };

        public UIInputs(bool enable = true) : base(enable)
        {
            controls.UI.Submit.started += OnPressSubmit;
            controls.UI.Cancel.started += OnPressCancel;
            controls.UI.Move.started += OnPressMove;
            controls.UI.LeftTab.started += OnPressLeftTab;
            controls.UI.RightTab.started += OnPressRightTab;
        }

        private void OnPressMove(InputAction.CallbackContext obj)
        {
            Vector2 direction = obj.ReadValue<Vector2>();
            OnMove(direction);
        }

        private void OnPressSubmit(InputAction.CallbackContext _) => OnSubmit();
        private void OnPressCancel(InputAction.CallbackContext _) => OnCancel();
        private void OnPressLeftTab(InputAction.CallbackContext _) => OnLeftTab();
        private void OnPressRightTab(InputAction.CallbackContext _) => OnRightTab();
    }
}
