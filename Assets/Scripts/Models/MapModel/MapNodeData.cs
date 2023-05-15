using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Models.MapModel
{
    [CreateAssetMenu(menuName = "Map/MapNodeData")]
    public class MapNodeData : ScriptableObject
    {
        public List<MapConnectionData> connections => _connections;
        public List<WorldSide> exitSides => _exitSides;
        public Biome biome => _biome;
        public bool hasPortal => _hasPortal;
        public bool isBossNode => _isBossNode;
        public new string name => _name;

        [SerializeField]
        private string _name;
        [SerializeField]
        private Biome _biome;
        [SerializeField]
        private bool _hasPortal;
        [SerializeField]
        private bool _isBossNode;
        [SerializeField]
        private List<WorldSide> _exitSides;
        [SerializeField]
        private List<MapConnectionData> _connections;
    }
}