using TritanTest.Data;
using TritanTest.Inputs;
using UnityEngine;

namespace TritanTest.Gameplay.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform vfxPoint;
        [SerializeField] private PlayerUI ui;
        [SerializeField] private PlayerBody body;

        public PlayerBody Body => body;
        public PlayerInputs Inputs { get; private set; }
        public PlayerSettings Settings => GameSettings.Player;

        private void Awake()
        {
            Inputs = Application.isMobilePlatform ? new PlayerMobileInputs() : new PlayerPCInputs();

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

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody && other.attachedRigidbody.TryGetComponent(out ICollectable collectable))
            {
                ItemData item = collectable.Collect(vfxPoint);
                ui.AddItem(item); // In a more complex program, this would be added into an inventory class.
            }
        }
    }
}
