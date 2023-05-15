using EventSystem.Events;
using MonoBehaviours.GameObjects.Enemy;
using MonoBehaviours.Ui.Display;
using NaughtyAttributes;
using UnityEngine;

namespace Managers.LocationManagers.Spawner
{
    public class BossSpawner : LocationSubManager
    {
        [SerializeField]
        private GameObject _bossPrefab;
        [SerializeField]
        private EnemyBarBehaviour _firstBossHealthBar;
        [SerializeField]
        private VoidEvent _onBossDeath;
        [SerializeField]
        private float _difficultyMultiplier;
        
        private int _spawnTileX = 100;
        private int _spawnTileY= 100;

        [Button]
        public void IncreaseDifficulty()
        {
            _difficultyMultiplier += 0.25f;
        }

        public void SpawnBoss()
        {
            InstantiateNewBoss(_firstBossHealthBar);
        }
    
        private void InstantiateNewBoss(EnemyBarBehaviour bossHealthBar)
        {
            GameObject bossGO = Instantiate(_bossPrefab, _contentPane);
            bossGO.transform.position = new Vector3(_spawnTileX, _spawnTileY, 0);
            bossGO.GetComponent<BossBehaviour>().Initialize(_currentLocation, _onBossDeath, _difficultyMultiplier);
            bossGO.GetComponent<BossBehaviour>().SetHealthBar(bossHealthBar.GetComponent<EnemyBarBehaviour>());
            bossHealthBar.gameObject.SetActive(true);
            _currentLocation.enemies.Add(bossGO.GetComponent<BossBehaviour>());
        }
    }
}