﻿using UnityEngine;

namespace TritanTest.Shared.ExtensionMethods
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"There already have a instances of {typeof(T).Name}, Current: {Instance.gameObject} and new {gameObject}");
                return;
            }

            Instance = this as T;
        }
    }
}