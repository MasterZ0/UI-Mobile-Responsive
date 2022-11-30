using System;
using UnityEngine;

namespace TritanTest.UI.AppOptions
{
    [Serializable]
    public class VideoOptionsData
    {
        public ScreenOrientation orientation = ScreenOrientation.LandscapeLeft;
        public int graphicsQuality;
        public bool shadows = true;
        public int antiAliasing = 1;
    }

    [Serializable]
    public class AudioOptionsData // Serialized = 0 ~ 10 (Slider step values), 0 ~ 1 FMOD
    {
        public float masterVolume = 10f;
        public float musicVolume = 10f;
        public float sfxVolume = 10f;
        public float voiceVolume = 10f;
    }

    [Serializable]
    public class AccessibilityOptionsData
    {
        public bool blood = true;
        public bool shakeScreen = true;
        public bool gamepadVibration = true;
        public float defaultSensitivity = 5f;
        public float aimSensitivity = 5f;
    }

    [Serializable]
    public class InputOptionsData
    {
        public string bindingOverrides;
    }
}