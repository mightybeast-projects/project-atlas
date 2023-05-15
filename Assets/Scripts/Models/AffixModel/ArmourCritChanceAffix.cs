using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/ArmourCritChanceAffix")]
    public class ArmourCritChanceAffix : Affix
    {
        [SerializeField]
        private int _armourValue;
        [SerializeField]
        private ValueType _armourValueType;
        
        [SerializeField]
        private int _critChanceValue;
        private ValueType _critChanceValueType = ValueType.PERCENT;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_armourValue, _armourValueType, StatType.ARMOUR);
            AddAffixValueToStat(_critChanceValue, _critChanceValueType, StatType.CRIT_CHANCE);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_armourValue, _armourValueType, StatType.ARMOUR) 
                   + "\n" + 
                   GetValueDescription(_critChanceValue, _critChanceValueType, StatType.CRIT_CHANCE);
        }
    }
}