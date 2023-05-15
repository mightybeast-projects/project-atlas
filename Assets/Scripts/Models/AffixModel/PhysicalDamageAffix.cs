using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/PhysicalDamageAffix")]
    public class PhysicalDamageAffix : Affix
    {
        [SerializeField]
        protected int _value;
        [SerializeField]
        protected ValueType _valueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_value, _valueType, StatType.PHYSICAL_DAM);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_value, _valueType, StatType.PHYSICAL_DAM);
        }
    }
}