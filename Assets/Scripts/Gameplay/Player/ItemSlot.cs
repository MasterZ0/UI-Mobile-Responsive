using TMPro;
using TritanTest.Data;
using UnityEngine;
using UnityEngine.UI;

namespace TritanTest.Gameplay.Player
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text countTmp;

        private int currentAmount; 

        public void Setup(ItemData itemData)
        {
            icon.sprite = itemData.icon;
            currentAmount = 0;
            Increment();
        }

        public void Increment()
        {
            currentAmount++;
            countTmp.text = $"x{currentAmount}";
        }
    }
}