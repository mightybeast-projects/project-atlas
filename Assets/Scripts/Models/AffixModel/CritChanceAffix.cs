using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/CritChanceAffix")]
    public class CritChanceAffix : Affix
    {
        [SerializeField]
        protected int _value;
        [SerializeField]
        protected ValueType _valueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_value, _valueType, StatType.CRIT_CHANCE);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_value, _valueType, StatType.CRIT_CHANCE);
        }
    }
}