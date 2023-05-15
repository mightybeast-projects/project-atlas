using UnityEngine;

namespace Models.StatModel
{
    [CreateAssetMenu(menuName = "Player/AttackCharacterStat")]
    public class CharacterAttackStat : CharacterStat
    {
        public Sprite attackIcon => _attackIcon;

        public Color attackColor => _attackColor;
        
        [SerializeField]
        private Sprite _attackIcon;
        [SerializeField]
        private Color _attackColor; 
    }
}