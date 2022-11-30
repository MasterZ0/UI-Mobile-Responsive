using Sirenix.OdinInspector;
using System;
using UnityEngine;
using TritanTest.Shared;

namespace TritanTest.Data
{
    /// <summary>
    /// Storage all data and variables
    /// </summary>
    [CreateAssetMenu(menuName = MenuPath.Settings + "Game Settings", fileName = "NewGameSettings")]
    public class GameSettings : ScriptableObject 
    {
        [Title("Game Settings")]
        [SerializeField] private GeneralSettings generalSettings;
        [SerializeField] private PlayerSettings playerSettings;

        public static Action OnUpdateSettings { get; set; }
        public static GameSettings Instance { get; private set; }
        public static GeneralSettings General => Instance.generalSettings;
        public static PlayerSettings Player => Instance.playerSettings;

        public void OnValidate()
        {
            Initialize();
            OnUpdateSettings?.Invoke();
        }

        public void Initialize() => Instance = this;
    }
}
