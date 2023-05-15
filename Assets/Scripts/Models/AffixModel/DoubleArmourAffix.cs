using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/DoubleArmourAffix")]
    public class DoubleArmourAffix : Affix
    {
        [SerializeField]
        private int _firstArmourValue;
        private ValueType _firstArmourValueType = ValueType.FLAT;
        
        [SerializeField]
        private int _secondArmourValue;
        private ValueType _secondArmourValueType = ValueType.PERCENT;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_firstArmourValue, _firstArmourValueType, StatType.ARMOUR);
            AddAffixValueToStat(_secondArmourValue, _secondArmourValueType, StatType.ARMOUR);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_firstArmourValue, _firstArmourValueType, StatType.ARMOUR) 
                   + "\n" + 
                   GetValueDescription(_secondArmourValue, _secondArmourValueType, StatType.ARMOUR);
        }
    }
}