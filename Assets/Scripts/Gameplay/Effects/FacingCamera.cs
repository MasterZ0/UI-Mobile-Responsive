using TritanTest.Shared.ExtensionMethods;
using UnityEngine;

namespace TritanTest.Gameplay
{
    public class FacingCamera : MonoBehaviour
    {
        private void Update() => transform.LookAtY(MainCamera.Position);
    }
}