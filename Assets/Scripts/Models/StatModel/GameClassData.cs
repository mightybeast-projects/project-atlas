using System.Collections.Generic;
using Models.AffixModel;
using NaughtyAttributes;
using UnityEngine;

namespace Models.StatModel
{
    [CreateAssetMenu(menuName = "GameClassData")]
    public class GameClassData : ScriptableObject
    {
        public new string name => _name;
        public Sprite sprite => _sprite;
        public List<GameClassData> parentDatas => _parentDatas;
        public Affix affix => _affix;
        
        [SerializeField]
        private string _name;
        [SerializeField][ShowAssetPreview]
        private Sprite _sprite;
        [SerializeField][Expandable]
        private Affix _affix;
        [SerializeField]
        private List<GameClassData> _parentDatas;
    }
}