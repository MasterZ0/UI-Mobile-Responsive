using UnityEngine;
using TritanTest.Shared;
using Sirenix.OdinInspector;

namespace TritanTest.Data
{
    [CreateAssetMenu(menuName = MenuPath.SettingsGlobal + "Player", fileName = "New" + nameof(PlayerSettings))]
    public class PlayerSettings : SerializedScriptableObject
    {
        [Title("Player Settings")]
        [SerializeField] private bool mobileSimulator;
        [SerializeField] private float distanceToCollectItem = 1f;
        [SerializeField] private float speedBase = 5f;
        [SerializeField] private float speedIncrement = 1f;
        [SerializeField] private int speedCount = 4;
        [MinMaxSlider(0, 10, true)]
        [SerializeField] private Vector2 animationSpeedMultiplier = new Vector2(1, 3);


        public float DistanceToCollectItem => distanceToCollectItem;
        public int SpeedCount => speedCount;
        public float SpeedBase => speedBase;
        public float SpeedIncrement => speedIncrement;
        public Vector2 AnimationSpeedMultiplier => animationSpeedMultiplier;
        public bool MobileSimulator => mobileSimulator;
    }
}