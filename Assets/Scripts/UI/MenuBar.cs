using TritanTest.Data;
using UnityEngine;

namespace TritanTest.UI
{

    public class MenuBar : MonoBehaviour 
    {
        private RectTransform rectTransform;

        private Vector2 startPosition;
        private Vector2 nextPosition;

        private bool open;
        private bool moving;

        private Vector2 UpPosition => startPosition - new Vector2(0f, rectTransform.rect.size.y);
        private Vector2 DownPosition => startPosition + new Vector2(0f, rectTransform.rect.size.y);

        private const float Threshold = 0.02f;

        private void Awake()
        {
            rectTransform = transform as RectTransform;

            startPosition = rectTransform.anchoredPosition;
        }

        private void FixedUpdate()
        {
            if (!moving)
                return;

            rectTransform.anchoredPosition = Vector2.Lerp(rectTransform.anchoredPosition, nextPosition, GameSettings.General.MenuBarSpeed * Time.fixedDeltaTime);

            if (Vector2.Distance(rectTransform.anchoredPosition, nextPosition) <= Threshold)
            {
                rectTransform.anchoredPosition = nextPosition;
                moving = false;
            }
        }

        public void OnToggleUp()
        {
            moving = true;
            open = !open;

            nextPosition = open ? UpPosition : startPosition;
        }

        public void OnToggleDown()
        {
            moving = true;
            open = !open;

            nextPosition = open ? DownPosition : startPosition;
        }
    }
}