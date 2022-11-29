using System;
using UnityEngine;

namespace TritanTest
{
    public abstract class PlayerInputs : BaseInput
    {
        public event Action<Vector2> OnMove;

        public PlayerInputs(bool enable) : base(enable) { }

        protected void InvokeMove(Vector2 value) => OnMove?.Invoke(value);
    }
}
