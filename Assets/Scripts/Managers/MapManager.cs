using System.Collections.Generic;
using Enums;
using Models.MapModel;
using MonoBehaviours.Ui;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class MapManager : MonoBehaviour
    {
        public MapNodeBehaviour homeLocationMapNode => _homeLocationMapNode;
        public MapNodeBehaviour currentMapNode => _currentMapNode;
        public MapNodeBehaviour nextMapNode => _nextMapNode;
        public MapConnectionData nextConnection => _nextConnection;

        [SerializeField]
        private Transform _mapMarker;
        [SerializeField]
        private List<MapNodeBehaviour> _mapNodes;
        [SerializeField]
        private MapNodeBehaviour _homeLocationMapNode;
        [SerializeField]
        private MapNodeBehaviour _finalLocationNode;
        
        private MapNodeBehaviour _currentMapNode;
        private MapNodeBehaviour _nextMapNode;
        private MapConnectionData _nextConnection;

        public void SetNextMapNodeAndConnection(MapNodeBehaviour mapNode, MapConnectionData connection)
        {
            _nextMapNode = mapNode;
            _nextConnection = connection;
        }
        
        public void UpdateCurrentNodeAndMarker()
        {
            _currentMapNode = _nextMapNode;
            _mapMarker.position = currentMapNode.gameObject.transform.position + new Vector3(0, 10, 0);
        }
        
        public void ChooseNextMapNode(WorldSide exitSide)
        {
            _nextConnection = GetCurrentConnection(exitSide);
            _nextMapNode = GetMapNode(nextConnection.endNode.name);
            
            if (_nextMapNode.mapNodeStatus == MapNodeStatus.LOCKED)
                _nextMapNode.Unlock();
            
            _currentMapNode = _nextMapNode;
        }

        public void UnlockPortalOfCurrentMapNode()
        {
            _currentMapNode.UnlockPortal();
        }
        
        public void ClearCurrentMapNode()
        {
            _currentMapNode.cleared = true;
        }

        public void ChangePortalsButtonsStatusTo(bool status)
        {
            foreach (MapNodeBehaviour mapNode in _mapNodes)
            {
                if (mapNode.mapNodeStatus == MapNodeStatus.UNLOCKED_PORTAL)
                {
                    Button button = mapNode.gameObject.GetComponent<Button>();
                    button.enabled = status;
                }
            }
        }
        
        public void ResetNodesStatus()
        {
            foreach (MapNodeBehaviour node in _mapNodes)
            {
                node.cleared = false;
                node.mapNodeStatus = MapNodeStatus.LOCKED;
            }
            
            _finalLocationNode.cleared = false;
            _finalLocationNode.mapNodeStatus = MapNodeStatus.LOCKED;
        }
        
        [Button]
        public void UnlockFinalLocationNode()
        {
            _finalLocationNode.gameObject.SetActive(true);
        }

        private MapConnectionData GetCurrentConnection(WorldSide exitSide)
        {
            MapConnectionData mapConnection = null;

            foreach(MapConnectionData con in currentMapNode.mapNodeData.connections)
                if (con.startSide == exitSide)
                    mapConnection = con;

            return mapConnection;
        }

        private MapNodeBehaviour GetMapNode(string nodeName)
        {
            MapNodeBehaviour mapNode = null;
            
            foreach (MapNodeBehaviour mn in _mapNodes)
                if (mn.name == nodeName)
                    mapNode = mn;
        
            return mapNode;
        }
    }
}
