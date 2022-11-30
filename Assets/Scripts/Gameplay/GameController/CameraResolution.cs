using Cinemachine;
using UnityEngine;

namespace TritanTest.Gameplay
{
    [ExecuteAlways]
    public class CameraResolution : MonoBehaviour
    {
        [SerializeField] private bool canRunInEditMode;
        [Range(1f, 100f)]
        [SerializeField] private float width = 10f;
        [Space]
        [SerializeField] private CinemachineVirtualCamera mainCamera;

        private int screenSizeX = 0;
        private int screenSizeY = 0;

        private void Awake() => RescaleCamera();

        private void Reset() => TryGetComponent(out mainCamera);

        private void OnValidate() => RescaleCamera();

        private void LateUpdate() => RescaleCamera();

        private void RescaleCamera()
        {
            if (Screen.width == screenSizeX && Screen.height == screenSizeY)
                return;

            if (!Application.isPlaying && !canRunInEditMode)
                return;

            float orthographicSize = width * Screen.height / Screen.width * .5f;
            mainCamera.m_Lens.OrthographicSize = orthographicSize;

            screenSizeX = Screen.width;
            screenSizeY = Screen.height;
        }
    }
}
