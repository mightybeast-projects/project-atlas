using Enums;
using EventSystem.Events;
using Managers.LocationManagers.Factory;
using Models;
using Models.MapModel;
using MonoBehaviours.Ui;
using NaughtyAttributes;
using UnityEngine;

namespace Managers.LocationManagers
{
    public class LocationManager : MonoBehaviour
    {
        public static int locationWidth, locationHeight;
        
        [SerializeField] 
        private Transform _contentPane;
        [SerializeField] 
        private Transform _tileHolder;
        [SerializeField][BoxGroup("Scene events")]
        private VoidEvent _loadHubLocationScene;
        [SerializeField][BoxGroup("Scene events")]
        private VoidEvent _loadFinalLocationScene;
        [SerializeField][BoxGroup("Scene events")]
        private VoidEvent _loadLocationScene;

        [SerializeField]
        private LocationFactory _staticLocationFactory;
        [SerializeField]
        private LocationFactory _dynamicLocationFactory;
        
        private LocationFactory _factoryInUse;
        private MapNodeBehaviour _mapNode;
        private WorldSide _connectionEndSide;

        public void GetBiomeAndEndSideFrom(MapNodeBehaviour mapNode, MapConnectionData enterConnection)
        {
            _mapNode = mapNode;
            _connectionEndSide = enterConnection == null ? WorldSide.PORTAL : enterConnection.endSide;
        }
        
        public void CreateLocation()
        {
            switch (_mapNode.mapNodeData.biome)
            {
                case Biome.CASTLE:
                    _factoryInUse = _staticLocationFactory;
                    _factoryInUse.SetSceneToLoadEvent(_loadHubLocationScene);
                    break;
                case Biome.CORRUPTED_CASTLE:
                    _factoryInUse = _staticLocationFactory;
                    _factoryInUse.SetSceneToLoadEvent(_loadFinalLocationScene);
                    break;
                default:
                    _factoryInUse = _dynamicLocationFactory;
                    _factoryInUse.SetSceneToLoadEvent(_loadLocationScene);
                    break;
            }
            
            _factoryInUse.Initialize(_mapNode, _connectionEndSide);
            _factoryInUse.GenerateLocation();
        }

        public void DestroyCurrentLocation()
        {
            for (var i = 1; i < _contentPane.childCount; i++)
                Destroy(_contentPane.GetChild(i).gameObject);
            for (var i = 0; i < _tileHolder.childCount; i++)
                Destroy(_tileHolder.GetChild(i).gameObject);
        }
        
        public void SetLocationSize(Location location)
        {
            locationWidth = location.width;
            locationHeight = location.height;
        }
    }
}