using System.Collections.Generic;
using Models.ItemDataModel;
using UnityEngine;

namespace Managers.ItemSpawners
{
    public class PrismStoneSpawner : ItemSpawner
    {
        [SerializeField] private PrismStonesManager _prismStonesManager;
        
        private PrismStone _prismStone;

        public void SpawnPrismStoneShrine()
        {
            _itemShrines = new List<GameObject>();

            _prismStone = _prismStonesManager.GetCurrentPrismStone();
            if(_prismStone == null) return;
            
            _spawnPoint = _centerTileSpawnPoint;
            InstantiateNewPrismStoneShrine();
        }
        
        private void InstantiateNewPrismStoneShrine()
        {
            _itemDescription = "Prism stone. Pick up this item to progress the story";
            
            InstantiateNewItemShrine(_prismStone);
        }
    }
}