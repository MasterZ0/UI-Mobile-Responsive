using UnityEngine;

namespace TritanTest.UI
{
    /// <summary>
    /// Filters an UI element so its anchors fits mobile safe area.
    /// </summary>
    [ExecuteAlways]
    public class SafeAreaFilter : MonoBehaviour
    {
        private void Awake() => ApplyFilter();

        private void Update() => ApplyFilter(); // TODO: Improve

        private void ApplyFilter()
        {
            RectTransform rectTransform = (RectTransform)transform;
            Rect safeArea = Screen.safeArea;
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = anchorMin + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
        }
    }
}