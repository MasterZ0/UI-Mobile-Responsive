using TritanTest.Shared.ExtensionMethods;
using UnityEngine;

namespace TritanTest.UIElements
{
    public class TabContent : MonoBehaviour
    {
        [SerializeField] private GameObject firstGameObject;

        private TabPair tabPair;

        public void OnRequestClose() => tabPair.RequestCloseContent();

        internal void Init(TabPair controller) => tabPair = controller;

        internal void Show()
        {
            gameObject.SetActive(true);
            this.SelectWithDelay(firstGameObject);
        }

        internal void Hide() => gameObject.SetActive(false);
    }
}