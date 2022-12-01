using System;
using TritanTest.Data;
using UnityEngine;

namespace TritanTest.UI
{

    public class MenuBar : MonoBehaviour 
    {
        private RectTransform rectTransform;

        private Func<Vector2> getNextPosition;
        private Vector2 startPosition;

        private bool moving;
        private bool open;

        private Vector2 UpPosition => startPosition - new Vector2(0f, rectTransform.rect.size.y);
        private Vector2 DownPosition => startPosition + new Vector2(0f, rectTransform.rect.size.y);

        private const float Threshold = 0.02f;

        private void Awake()
        {
            rectTransform = transform as RectTransform;

            getNextPosition = () => startPosition;
            startPosition = rectTransform.anchoredPosition;
        }

        private void FixedUpdate()
        {
            Vector2 nextPosition = getNextPosition();

            if (!moving)
            {
                rectTransform.anchoredPosition = nextPosition;
                return;
            }

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

            getNextPosition = open ? (() => UpPosition) : (() => startPosition);
        }

        public void OnToggleDown()
        {
            moving = true;
            open = !open;

            getNextPosition = open ? (() => DownPosition) : (() => startPosition);
        }
    }
}