using Sirenix.OdinInspector;
using UnityEngine;
using TritanTest.Shared;
using System.Collections.Generic;

namespace TritanTest.Data
{
    [CreateAssetMenu(menuName = MenuPath.SettingsGlobal + "General", fileName = "GeneralSettings")]
    public class GeneralSettings : ScriptableObject
    {
        [Title("UI")]
        [SerializeField] private float menuBarSpeed = 5f;

        [Title("Arena")]
        [SerializeField] private int maxSpawnedItems = 10;
        [SerializeField] private float timeToSpawnItem = 2f;
        [SerializeField] private float searchRadius = 1f;
        [SerializeField] private Vector2 spawnArea = new Vector2(10, 10);
        [SerializeField] private List<ItemData> items;

        public List<ItemData> Items => items;
        public float TimeToSpawnItem => timeToSpawnItem;
        public Vector2 SpawnArea => spawnArea;

        public int MaxSpawnedItems => maxSpawnedItems;
        public float SearchRadius => searchRadius;
        public float MenuBarSpeed => menuBarSpeed;
    }
}