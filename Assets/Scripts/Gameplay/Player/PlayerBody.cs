using Sirenix.OdinInspector;
using System;
using TritanTest.Shared.ExtensionMethods;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TritanTest.Gameplay.Player
{
    [Serializable, FoldoutGroup("Body"), InlineProperty, HideLabel]
    public class PlayerBody
    {
        [Header("Body")]
        [SerializeField] private Transform goVFX;
        [SerializeField] private LayerMask interactableLayer;

        [Header("Animations")]
        [SerializeField] private Animator animator;
        [Space]
        [Range(0, 1)]
        [SerializeField] private float animationTransition = 0.25f;
        [SerializeField] private string idleState = "Idle";
        [SerializeField] private string runState = "Run";
        [SerializeField] private string speedMultiplierParameter = "SpeedMultiplier";

        private Vector3 targetPosition;
        private bool moving;
        private float moveSpeed;

        private PlayerController Controller { get; set; }
        private Transform Transform => Controller.transform;

        internal void Init(PlayerController playerController)
        {
            Controller = playerController;
            targetPosition = Transform.position;

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
            if (Vector3.Distance(newPosition, targetPosition) <= 0.01f)
            {
                animator.CrossFade(idleState, animationTransition);
                moving = false;
            }
        }

        private void OnMove(Vector2 screenPosition)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

            Ray ray = MainCamera.Camera.ScreenPointToRay(screenPosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, interactableLayer) && hit.point.y == 0)
            {
                Transform.LookAtY(targetPosition);
                targetPosition = hit.point;

                goVFX.position = targetPosition;
                goVFX.gameObject.SetActive(true);

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
