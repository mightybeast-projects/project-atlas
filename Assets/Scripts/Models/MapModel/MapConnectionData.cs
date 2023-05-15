using System.Linq;
using Enums;
using NaughtyAttributes;
using UnityEngine;

namespace Models.MapModel
{
    [CreateAssetMenu(menuName = "Map/MapConnectionData")]
    public class MapConnectionData : ScriptableObject
    {
        public WorldSide startSide => _startSide;
        public WorldSide endSide => _endSide;
        public MapNodeData endNode => _endNode;
        
        [SerializeField]
        private WorldSide _startSide;
        [SerializeField]
        private WorldSide _endSide;
        [SerializeField][Expandable]
        private MapNodeData _startNode;
        [SerializeField][Expandable]
        private MapNodeData _endNode;

        private void OnValidate()
        {
            if (FieldsAreEmpty() || StartNodeContainsThisConnection()) return;

            _startNode.connections.Add(this);
                
            _startNode.exitSides.Add(_startSide);
        }

        private bool FieldsAreEmpty()
        {
            return _startNode == null || _endNode == null;
        }

        private bool StartNodeContainsThisConnection()
        {
            return _startNode.connections.Any(connection => connection.startSide == startSide);
        }
    }
}