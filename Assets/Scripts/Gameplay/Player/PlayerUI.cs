using System.Collections.Generic;
using TritanTest.Data;
using TritanTest.ObjectPooling;
using TritanTest.Shared.ExtensionMethods;
using TritanTest.UIElements;
using UnityEngine;

namespace TritanTest.Gameplay.Player
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Navigator speedNavigator;
        [SerializeField] private Transform itemsContainer;
        [SerializeField] private ItemSlot itemSlotPrefab;

        private float[] speeds;

        private readonly Dictionary<ItemData, ItemSlot> slots = new Dictionary<ItemData, ItemSlot>();

        private PlayerController Controller { get; set; }
        private PlayerSettings Settings => Controller.Settings;

        public void Init(PlayerController playerController)
        {
            Controller = playerController;
            SetupSpeed();
            OnSetSpeed(0);
        }

        private void SetupSpeed()
        {
            speeds = new float[Settings.SpeedCount];
            string[] stringPackage = new string[Settings.SpeedCount];
            for (int i = 0; i < speeds.Length; i++)
            {
                speeds[i] = Settings.SpeedBase + Settings.SpeedIncrement * i;
                stringPackage[i] = $"x{speeds[i]}";
            }

            speedNavigator.Init(stringPackage, 0);
        }

        public void AddItem(ItemData newItem)
        {
            if (!slots.ContainsKey(newItem))
            {
                ItemSlot newSlot = itemSlotPrefab.SpawnPooledObject(itemsContainer);
                newSlot.Setup(newItem);
                slots[newItem] = newSlot;
            }
            else
            {
                slots[newItem].Increment();
            }
        }

        public void OnSetSpeed(int index)
        {
            float minSpeed = Settings.SpeedBase;
            float maxSpeed = minSpeed + Settings.SpeedIncrement * Settings.SpeedCount - 1;
            float speedMultiplier = speeds[index].Remap(minSpeed, maxSpeed, Settings.AnimationSpeedMultiplier.x, Settings.AnimationSpeedMultiplier.y);
            Controller.Body.SetSpeed(speeds[index], speedMultiplier);
        }
    }
}