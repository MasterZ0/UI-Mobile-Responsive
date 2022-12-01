using UnityEngine;
using Sirenix.OdinInspector;
using TritanTest.UIElements;

namespace TritanTest.UI.AppOptions
{
    public class VideoOptions : MonoBehaviour
    {
        [Title("Video")]
        [SerializeField] private string on;
        [SerializeField] private string off;
        [Space]
        [SerializeField] private string qualityLow;
        [SerializeField] private string qualityMedium;
        [SerializeField] private string qualityHigh;
        [Space]
        [SerializeField] private string landscapeLeft;
        [SerializeField] private string landscapeRight;
        [SerializeField] private string portrait;
        [SerializeField] private string autoRotation;

        [Header("Components")]
        [SerializeField] private Navigator orientationNavigator;
        [SerializeField] private Navigator graphicsQualityNavigator;
        [SerializeField] private Navigator shadowsNavigator;
        [SerializeField] private Navigator antiAliasingNavigator;

        private VideoOptionsData videoData;

        private string[] ToggleOptions => new string[] { off, on };
        private string[] GraphicQualityOptions => new string[] { qualityLow, qualityMedium, qualityHigh };
        private string[] OrientationOptions => new string[] { landscapeLeft, landscapeRight, portrait, autoRotation };

        /*
        private void Awake()
        {
            LocalizationManager.OnLocalizeEvent += UpdateFullScreenTexts;
        }

        private void OnDestroy()
        {
            LocalizationManager.OnLocalizeEvent -= UpdateFullScreenTexts;
        }

        private void OnDisable()
        {
            PersistenceManager.SaveGlobalFile(videoData);
        }

        private void UpdateFullScreenTexts()
        {
            fullScreenNavigator.UpdateTexts(ToggleOptions);
            shadowsNavigator.UpdateTexts(ToggleOptions);
            antiAliasingNavigator.UpdateTexts(ToggleOptions);
            graphicsQualityNavigator.UpdateTexts(GraphicQualityOptions);
        }*/

        public void LoadSettings()
        {
            //videoData = PersistenceManager.LoadGlobalFile<VideoOptionsData>();

            if (videoData == null)
            {
                videoData = new VideoOptionsData();

                videoData.graphicsQuality = QualitySettings.GetQualityLevel();
                videoData.orientation = Screen.orientation;

                //PersistenceManager.SaveGlobalFile(videoData);
            }

            int orientationIndex = videoData.orientation switch
            {
                ScreenOrientation.LandscapeLeft => 0,
                ScreenOrientation.LandscapeRight => 1,
                ScreenOrientation.Portrait => 2,
                ScreenOrientation.AutoRotation => 3,
                _ => throw new System.NotImplementedException()
            };

            // Navigators
            graphicsQualityNavigator.Init(GraphicQualityOptions, videoData.graphicsQuality);
            shadowsNavigator.Init(ToggleOptions, videoData.shadows ? 1 : 0);
            antiAliasingNavigator.Init(ToggleOptions, videoData.antiAliasing);
            orientationNavigator.Init(OrientationOptions, orientationIndex);

            // Set values
            QualitySettings.SetQualityLevel(videoData.graphicsQuality);
            QualitySettings.shadows = videoData.shadows ? ShadowQuality.All : ShadowQuality.Disable;
            QualitySettings.antiAliasing = videoData.antiAliasing;
            Screen.orientation = videoData.orientation;
        }

        #region Set Option
        public void OnSetOrientation(int orientationIndex)
        {
            Screen.orientation = orientationIndex switch
            {
                0 => ScreenOrientation.LandscapeLeft,
                1 => ScreenOrientation.LandscapeRight,
                2 => ScreenOrientation.Portrait,
                3 => ScreenOrientation.AutoRotation,
                _ => throw new System.NotImplementedException()
            };

            videoData.orientation = Screen.orientation;
        }

        public void OnSetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
            videoData.graphicsQuality = qualityIndex;

            // Keep values
            QualitySettings.shadows = videoData.shadows ? ShadowQuality.All : ShadowQuality.Disable;
            QualitySettings.antiAliasing = videoData.antiAliasing;
        }

        public void OnSetAntiAliasing(int value)
        {
            QualitySettings.antiAliasing = value;
            videoData.antiAliasing = value;
        }

        public void OnSetShadows(int value)
        {
            bool active = value == 1 ? true : false;
            QualitySettings.shadows = active ? ShadowQuality.All : ShadowQuality.Disable;
            videoData.shadows = active;
        }
        #endregion
    }
}