using Enums;
using EventSystem.Events;
using Managers.LocationManagers.Spawner;
using Models;
using MonoBehaviours.Ui;
using NaughtyAttributes;
using UnityEngine;

namespace Managers.LocationManagers.Factory
{
    public abstract class LocationFactory : LocationSubManager
    {
        [SerializeField][Range(24, 36)]
        private int _locationTWidth;
        [SerializeField][Range(24, 36)]
        private int _locationTHeight;

        [SerializeField] private GridManager _gridManager;
        [SerializeField] private LocationRatioRandomizer _locationRatioRandomizer;
        [SerializeField] protected PlayerSpawner _playerSpawner;
        
        [SerializeField][BoxGroup("Location events")]
        private LocationEvent _onLocationCreated;
        [SerializeField][BoxGroup("Location events")]
        private LocationEvent _onLocationConstructed;

        private VoidEvent _sceneToLoadEvent;
        protected MapNodeBehaviour _mapNode;
        private WorldSide _enterConnectionEndSide;
        
        public void Initialize(MapNodeBehaviour mapNode, WorldSide enterConnectionEndSide)
        {
            _mapNode = mapNode;
            _enterConnectionEndSide = enterConnectionEndSide;
        }
        
        public virtual void GenerateLocation()
        {
            _sceneToLoadEvent.Raise();
            
            GenerateEmptyLocation();
            _playerSpawner.SpawnPlayer(_currentLocation.startSide);
        }
        
        public void SetSceneToLoadEvent(VoidEvent sceneToLoadEvent)
        {
            _sceneToLoadEvent = sceneToLoadEvent;
        }

        private void GenerateEmptyLocation()
        {
            CreateNewLocation();

            ConstructLocation();
        }

        private void CreateNewLocation()
        {
            _currentLocation = new Location(_locationTWidth, _locationTHeight, 
                _enterConnectionEndSide, _mapNode.mapNodeData.exitSides, _mapNode.mapNodeData.biome);

            _onLocationCreated.Raise(_currentLocation);
        }
        
        private void ConstructLocation()
        {
            _gridManager.InstantiateGrid();
            _locationRatioRandomizer.RandomiseLocationRatios();

            _onLocationConstructed.Raise(_currentLocation);
        }
    }
}