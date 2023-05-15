using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/DoubleHealthAffix")]
    public class DoubleHealthAffix : Affix
    {
        [SerializeField]
        private int _firstHealthValue;
        private ValueType _firstHealthValueType = ValueType.FLAT;
        
        [SerializeField]
        private int _secondHealthValue;
        private ValueType _secondHealthValueType = ValueType.PERCENT;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_firstHealthValue, _firstHealthValueType, StatType.MAXIMUM_HEALTH);
            AddAffixValueToStat(_secondHealthValue, _secondHealthValueType, StatType.MAXIMUM_HEALTH);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_firstHealthValue, _firstHealthValueType, StatType.MAXIMUM_HEALTH) 
                   + "\n" + 
                   GetValueDescription(_secondHealthValue, _secondHealthValueType, StatType.MAXIMUM_HEALTH);
        }
    }
}