using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/HealthAffix")]
    public class HealthAffix : Affix
    {
        [SerializeField]
        protected int _value;
        [SerializeField]
        protected ValueType _valueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_value, _valueType, StatType.MAXIMUM_HEALTH);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_value, _valueType, StatType.MAXIMUM_HEALTH);
        }
    }
}