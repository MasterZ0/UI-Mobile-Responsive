using TritanTest.Inputs;
using UnityEngine;

namespace TritanTest
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform goVFX;
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask interactableLayer;
        [SerializeField] private float moveSpeed;

        private PlayerInputs Inputs { get; set; }
        private Vector3 targetPosition;

        private void Awake()
        {
            targetPosition = transform.position;

            Inputs = Application.isMobilePlatform ? new PlayerMobileInputs() : new PlayerPCInputs();
            Inputs.OnMove += OnMove;
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
        }

        private void OnMove(Vector2 screenPosition)
        {
            Ray ray = mainCamera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, interactableLayer))
            {
                if (hit.point.y == 0)
                {
                    targetPosition = hit.point;

                    goVFX.position = targetPosition;
                    goVFX.gameObject.SetActive(true);
                }
            }
        }
    }
}
