using System.Collections.Generic;
using Models.ItemDataModel;
using UnityEngine;

namespace Managers.ItemSpawners
{
    public class EquipSpawner : ItemSpawner
    {
        [SerializeField] private List<Equip> _equipAssets;
        
        public void SpawnEquipShrines()
        {
            _itemShrines = new List<GameObject>();
            
            _spawnPoint = _centerTileSpawnPoint + new Vector3(-80, 64, 0);
            InstantiateNewEquipShrine();
            _spawnPoint = _centerTileSpawnPoint + new Vector3(80, 64, 0);
            InstantiateNewEquipShrine();
            _spawnPoint = _centerTileSpawnPoint + new Vector3(0, -64, 0);
            InstantiateNewEquipShrine();
        }
        
        private void InstantiateNewEquipShrine()
        {
            Equip equip = GenerateEquipItem();
            _itemDescription = equip.affix.GetBasicDescription();
            
            InstantiateNewItemShrine(equip);
        }
        
        private Equip GenerateEquipItem()
        {
            int index = Random.Range(0, _equipAssets.Count);
            Equip equip = _equipAssets[index];
        
            return equip;
        }
    }
}