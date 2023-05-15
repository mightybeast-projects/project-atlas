using Enums;
using Models.Value;
using NaughtyAttributes;
using UnityEngine;

namespace Models.StatModel
{
    [CreateAssetMenu(menuName = "Player/CharacterStat")]
    public class CharacterStat : ScriptableObject
    {
        public StatType statType => _statType;
        public FloatValue statValue => _statValue;

        public float addedFlatAmount { get; set; }

        public float multiplicativePercentAmount { get; set; }

        [SerializeField]
        protected StatType _statType;
        [SerializeField][Expandable]
        protected FloatValue _statValue;

        public void RecalculateStat()
        {
            float flatAmount = _statValue.baseValue + addedFlatAmount;
            _statValue.value = flatAmount + multiplicativePercentAmount * flatAmount / 100;
        }
    }
}