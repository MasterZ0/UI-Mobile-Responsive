using System.Collections.Generic;
using TritanTest.Data;
using TritanTest.ObjectPooling;
using TritanTest.Shared.ExtensionMethods;
using UnityEngine;

namespace TritanTest.Gameplay
{
    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class GameController : MonoBehaviour 
    {
        [SerializeField] private LayerMask obstables;
        [SerializeField] private Item item;
        [SerializeField] private Transform itemContainer;

        private GeneralSettings Settings => GameSettings.General;

        private float timer;

        private Vector3 SpawnArea => new Vector3()
        {
            x = Settings.SpawnArea.x,
            y = 0,
            z = Settings.SpawnArea.y
        };

        private void FixedUpdate()
        {
            if (itemContainer.childCount >= Settings.MaxSpawnedItems)
                return;

            timer += Time.fixedDeltaTime;
            if (timer >= Settings.TimeToSpawnItem)
            {
                timer -= Settings.TimeToSpawnItem;
                SpawnItem();
            }
        }

        private void OnDrawGizmosSelected()
        {
            Vector3 size = SpawnArea;
            size.y = 0.1f;
            Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
            Gizmos.DrawCube(transform.position, size);
        }

        public void SpawnItem()
        {
            List<ItemData> itemList = Settings.Items;
            int index = Random.Range(0, itemList.Count);
            ItemData selectedItem = itemList[index];

            Vector3 position = FindPosition();
            Item instance = ObjectPool.SpawnPooledObject(item, position, Quaternion.identity, itemContainer);
            instance.SetItem(selectedItem);
        }

        private Vector3 FindPosition()
        {
            bool canSpawn = false;
            Vector3 position = Vector3.zero;

            while (!canSpawn)
            {
                float halfX = Settings.SpawnArea.x / 2f;
                float halfZ = Settings.SpawnArea.y / 2f;
                Vector2 xRange = new Vector2(transform.position.x - halfX, transform.position.x + halfX);
                Vector2 zRange = new Vector2(transform.position.z - halfZ, transform.position.z + halfZ);

                position = new Vector3()
                {
                    x = xRange.RandomRange(),
                    y = transform.position.y,
                    z = zRange.RandomRange()
                };

                canSpawn = !Physics.CheckSphere(position, Settings.SearchRadius, obstables);
            }

            return position;
        }
    }
}