using System.Collections.Generic;
using EventSystem.Events;
using MonoBehaviours.GameObjects.Enemy;
using NaughtyAttributes;
using UnityEngine;

namespace Managers.LocationManagers.Spawner
{
    public class EnemySpawner : LocationSubManager
    {
        [SerializeField] 
        private List<GameObject> _enemyPrefabs;
        [SerializeField]
        private VoidEvent _onEnemyDeath;
        [SerializeField][Range(0, 10)]
        private int _spawnPointsCounter;
        [SerializeField]
        private float _difficultyMultiplier;

        private int _spawnTileIndexX;
        private int _spawnTileIndexY;
        private GameObject _enemyPrefab;

        [Button]
        public void IncreaseDifficulty()
        {
            _difficultyMultiplier += 0.5f;
        }
        
        internal void SpawnEnemies()
        {
            for (var i = 0; i < _spawnPointsCounter; i++) 
                SpawnNewEnemy();
        }

        private void SpawnNewEnemy()
        {
            ChooseSpawnTileIndexes();
            ChooseEnemyPrefab();
            InstantiateNewEnemy();
        }

        private void ChooseSpawnTileIndexes()
        {
            _spawnTileIndexX = Random.Range(2, _currentLocation.grid.GetLength(0) - 2);
            _spawnTileIndexY = Random.Range(2, _currentLocation.grid.GetLength(1) - 2);
        }

        private void  ChooseEnemyPrefab()
        {
            _enemyPrefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Count)];
        }

        private void InstantiateNewEnemy()
        {
            var spawnPointTile = _currentLocation.grid[_spawnTileIndexX, _spawnTileIndexY];
            var enemyGameObject = Instantiate(_enemyPrefab, _contentPane);

            enemyGameObject.transform.position = spawnPointTile.gameObject.transform.position;
            EnemyBehaviour enemyBehaviour = enemyGameObject.GetComponent<EnemyBehaviour>();
            enemyBehaviour.Initialize(_currentLocation, _onEnemyDeath, _difficultyMultiplier);

            _currentLocation.enemies.Add(enemyBehaviour);
        }
    }
}