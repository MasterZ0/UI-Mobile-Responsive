using TritanTest.Data;
using TritanTest.Inputs;
using UnityEngine;

namespace TritanTest.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform center;
        [SerializeField] private PlayerUI ui;
        [SerializeField] private PlayerBody body;

        public Transform Center => center;
        public PlayerBody Body => body;
        public PlayerUI UI => ui;
        public PlayerInputs Inputs { get; private set; }
        public PlayerSettings Settings => GameSettings.Player;

        private void Awake()
        {
            Inputs = Application.isMobilePlatform || Settings.MobileSimulator ? new PlayerMobileInputs() : new PlayerPCInputs();

            ui.Init(this);
            body.Init(this);
        }

        private void OnDestroy()
        {
            Inputs.Dispose();
        }

        private void FixedUpdate()
        {
            body.Update();
        }
    }
}
