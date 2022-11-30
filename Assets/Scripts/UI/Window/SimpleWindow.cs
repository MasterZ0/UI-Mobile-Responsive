using System.Collections.Generic;
using TritanTest.Shared;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace TritanTest.UI.Window
{
    /// <summary>
    /// Generic and basic implementation
    /// </summary>
    public class SimpleWindow : MonoBehaviour, IWindow, IInitable
    {
        [Header("Simple Window")]
        [SerializeField] private GameObject firstBtn;
        [SerializeField] private GameEvent onRequestOpen;
        [Space]
        [SerializeField] private UnityEvent onOpen;
        [SerializeField] private UnityEvent onClose;

        public GameObject FirstGameObject => firstBtn;

        public void Init()
        {
            if (onRequestOpen)
            {
                onRequestOpen += OnRequestToOpen;
            }
        }

        private void OnDestroy()
        {
            if (onRequestOpen)
            {
                onRequestOpen -= OnRequestToOpen;
            }
        }

        public virtual void OpenWindow()
        {
            gameObject.SetActive(true);
            onOpen.Invoke();
        }

        public virtual void CloseWindow()
        {
            gameObject.SetActive(false);
            onClose.Invoke();
        }

        public void OnRequestToOpen() => this.RequestOpenWindow();

        public void OnRequestToClose() => this.TryCloseWindow();

        public void OnRequestToCloseAll() => WindowManager.CloseAllWindows();
    }
}