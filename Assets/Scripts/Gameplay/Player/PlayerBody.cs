using Sirenix.OdinInspector;
using System;
using TritanTest.Data;
using TritanTest.Shared.ExtensionMethods;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TritanTest.Gameplay.Player
{
    [Serializable, FoldoutGroup("Body"), InlineProperty, HideLabel]
    public class PlayerBody
    {
        [Header("Body")]
        [SerializeField] private GameObject movementPoint;
        [SerializeField] private LayerMask interactableLayer;

        [Header("Animations")]
        [SerializeField] private Animator animator;
        [Space]
        [Range(0, 1)]
        [SerializeField] private float animationTransition = 0.25f;
        [SerializeField] private string idleState = "Idle";
        [SerializeField] private string runState = "Run";
        [SerializeField] private string speedMultiplierParameter = "SpeedMultiplier";

        private PlayerSettings Settings => Controller.Settings;

        private Vector3 targetPosition;
        private ICollectable collectable;

        private float moveSpeed;
        private float distanceToStop;
        private bool moving;

        private PlayerController Controller { get; set; }
        private Transform Transform => Controller.transform;

        private const float Threshold = 0.01f;

        internal void Init(PlayerController playerController)
        {
            Controller = playerController;
            targetPosition = Transform.position;
            movementPoint.transform.SetParent(null);
            movementPoint.SetActive(false);

            Controller.Inputs.OnMove += OnMove;
        }

        public void Update()
        {
            if (!moving)
                return;

            // Move
            Vector3 newPosition = Vector3.MoveTowards(Transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);
            Transform.position = newPosition;

            // Stop
            if (Vector3.Distance(newPosition, targetPosition) <= distanceToStop)
            {
                movementPoint.SetActive(false);
                animator.CrossFade(idleState, animationTransition);
                moving = false;

                if (collectable != null)
                {
                    ItemData item = collectable.Collect(Controller.Center);
                    Controller.UI.AddItem(item); // In a more complex program, this would be added into an inventory class.

                    collectable = null;
                }
            }
        }

        private void OnMove(Vector2 screenPosition)
        {
            collectable = null; // Clean last interaction

            Ray ray = MainCamera.Camera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, interactableLayer))
            {
                if (hit.rigidbody && hit.rigidbody.TryGetComponent(out collectable))
                {
                    targetPosition = collectable.Pivot.position;
                    distanceToStop = Settings.DistanceToCollectItem;
                }
                else if (hit.point.y == 0)
                {
                    targetPosition = hit.point;
                    distanceToStop = Threshold;
                }
                else
                    return;

                movementPoint.transform.position = targetPosition;
                movementPoint.SetActive(true);

                Transform.LookAtY(targetPosition);

                if (!moving)
                {
                    moving = true;
                    animator.CrossFade(runState, animationTransition);
                }
            }
        }

        public void SetSpeed(float moveSpeed, float speedMultiplier)
        {
            this.moveSpeed = moveSpeed;
            animator.SetFloat(speedMultiplierParameter, speedMultiplier);
        }
    }
}
