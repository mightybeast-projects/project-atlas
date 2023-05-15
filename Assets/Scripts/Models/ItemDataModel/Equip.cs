using Interfaces;
using Models.AffixModel;
using Models.GameObjectModel;
using NaughtyAttributes;
using UnityEngine;

namespace Models.ItemDataModel
{
    [CreateAssetMenu(menuName = "EquipData")]
    public class Equip : Item, IEquipable
    {
        [SerializeField][Expandable]
        private Affix _affix;
        public Affix affix => _affix;

        public void EquipOn(Character character)
        {
            Inventory inventory = character.inventory;
            
            _affix.ApplyTo(character);
            
            foreach (Inventory.InventorySlot itemSlot in inventory.itemSlots)
            {
                if(itemSlot.item.name == name){
                    itemSlot.amount++;
                    return;
                }
            }
        
            inventory.itemSlots.Add(new Inventory.InventorySlot(this, 1));
        }
    }
}