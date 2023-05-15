using Managers.LocationManagers.Spawner;
using UnityEngine;

namespace Managers.LocationManagers.Factory
{
    public class DynamicLocationFactory : LocationFactory
    {
        [SerializeField] private StaticObjectSpawner _staticObjectSpawner;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private BossSpawner _bossSpawner;
        [SerializeField] private ExitsManager _exitsManager;
        
        public override void GenerateLocation()
        {
            base.GenerateLocation();
            _contentPane.gameObject.SetActive(true);

            if (_mapNode.mapNodeData.hasPortal)
                _staticObjectSpawner.SpawnPortal(_mapNode);

            _staticObjectSpawner.SpawnBuffShrines();

            if(!_mapNode.cleared)
            {
                if(_mapNode.mapNodeData.isBossNode)
                    _bossSpawner.SpawnBoss();
                else
                    _enemySpawner.SpawnEnemies();
            }
            else 
                _exitsManager.AddExits();
        }
    }
}