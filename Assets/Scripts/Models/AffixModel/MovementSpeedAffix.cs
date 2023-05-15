using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/MovementSpeedAffix")]
    public class MovementSpeedAffix : Affix
    {
        [SerializeField]
        protected int _value;
        [SerializeField]
        protected ValueType _valueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_value, _valueType, StatType.MOVEMENT_SPEED);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_value, _valueType, StatType.MOVEMENT_SPEED);
        }
    }
}