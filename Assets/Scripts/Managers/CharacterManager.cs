using System.Collections.Generic;
using Models;
using Models.GameObjectModel;
using Models.StatModel;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace Managers
{
    public class CharacterManager : MonoBehaviour
    {
        public CharacterScript characterBehaviour => _characterBehaviour;

        [SerializeField]
        private CharacterScript _characterBehaviour;
        [SerializeField]
        private Character _character;

        private void OnApplicationQuit()
        {
            ResetCharacterData();
        }

        public void ResetCharacterData()
        {
            _character.inventory.itemSlots = new List<Inventory.InventorySlot>();
            _character.prismStonePouch.itemSlots = new List<Inventory.InventorySlot>();

            for (int i = 0; i < _character.stats.statList.Count; i++)
                ResetStat(i);
            
            _characterBehaviour.ResetData();
            _character.ResetHealth();
        }

        private void ResetStat(int i)
        {
            CharacterStat stat = _character.stats.statList[i];

            stat.addedFlatAmount = 0;
            stat.multiplicativePercentAmount = 0;
            stat.statValue.value = stat.statValue.baseValue;
        }
    }
}