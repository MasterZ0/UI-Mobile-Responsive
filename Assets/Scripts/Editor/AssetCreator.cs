using UnityEditor;
using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace TritanTest.Editor
{
    [Serializable]
    public class AssetCreator<T> where T : ScriptableObject
    {
        [TitleGroup("File Settings"), HorizontalGroup("File Settings/Main")]
        [SerializeField] private string fileName;

        [ShowInInspector]
        private string AssetPath => $"{Path}/{fileName}.asset";

        private string Path { get; }

        /// <param name="path"> Path inside the project. Ex: Assets/Data </param>
        public AssetCreator(string path)
        {
            Path = path;
            fileName = "New" + typeof(T).Name;
        }

        [HorizontalGroup("File Settings/Main"), Button]
        private void Create()
        {
            T itemData = ScriptableObject.CreateInstance(typeof(T)) as T;
            AssetDatabase.CreateAsset(itemData, AssetPath);
        }
    }
}