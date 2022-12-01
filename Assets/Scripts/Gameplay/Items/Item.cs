using TritanTest.Data;
using TritanTest.ObjectPooling;
using UnityEngine;

namespace TritanTest.Gameplay
{

    /// <summary>
    /// Note to developers: Please describe what this MonoBehaviour does.
    /// </summary>
    public class Item : MonoBehaviour, ICollectable
    {
        [Header("Item")]
        [SerializeField] private SpriteRenderer spriteRenderer;

        public Transform Pivot => transform;

        private ItemData item;

        public void SetItem(ItemData itemData)
        {
            item = itemData;
            spriteRenderer.sprite = itemData.icon;
        }

        public ItemData Collect(Transform fxParent)
        {
            ObjectPool.SpawnPooledObject(item.collectFX, fxParent.position, fxParent.rotation, fxParent);
            this.ReturnToPool();
            return item;
        }
    }
}