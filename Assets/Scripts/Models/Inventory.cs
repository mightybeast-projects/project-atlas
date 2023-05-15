using System;
using System.Collections.Generic;
using Models.ItemDataModel;
using NaughtyAttributes;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Player/Inventory")]
    public class Inventory : ScriptableObject
    {
        [SerializeField]
        private List<InventorySlot> _itemSlots = new List<InventorySlot>();

        public List<InventorySlot> itemSlots
        {
            get => _itemSlots;
            set => _itemSlots = value;
        }
        
        [Serializable]
        public class InventorySlot
        {
            public Item item => _item;

            public int amount
            {
                get => _amount;
                set => _amount = value;
            }

            [SerializeField][Expandable]
            private Item _item;
            [SerializeField]
            private int _amount;
            
            public InventorySlot(Item item, int amount)
            {
                _item = item;
                _amount = amount;
            }
        }
    }
}