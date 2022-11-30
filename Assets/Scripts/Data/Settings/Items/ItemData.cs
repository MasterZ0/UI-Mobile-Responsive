using Sirenix.OdinInspector;
using UnityEngine;

namespace TritanTest.Data
{
    public class ItemData : ScriptableObject, IEditableAsset
    {
        [PreviewField(75)]
        public Sprite icon;
        public Transform collectFX;
    }
}