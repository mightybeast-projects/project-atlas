using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/ArmourAffix")]
    public class ArmourAffix : Affix
    {
        [SerializeField]
        protected int _value;
        [SerializeField]
        protected ValueType _valueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_value, _valueType, StatType.ARMOUR);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_value, _valueType, StatType.ARMOUR);
        }
    }
}