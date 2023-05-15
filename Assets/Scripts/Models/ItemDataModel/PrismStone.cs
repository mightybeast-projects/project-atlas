using Enums;
using Interfaces;
using Models.GameObjectModel;
using UnityEngine;

namespace Models.ItemDataModel
{
    [CreateAssetMenu(menuName = "PrismStoneData")]
    public class PrismStone: Item, IEquipable
    {
        public Biome biome => _biome;
        
        [SerializeField]
        private Biome _biome;
        
        public void EquipOn(Character character)
        {
            character.prismStonePouch.itemSlots.Add(new Inventory.InventorySlot(this, 1));
        }
    }
}