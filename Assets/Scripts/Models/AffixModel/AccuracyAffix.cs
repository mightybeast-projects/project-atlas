using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/AccuracyAffix")]
    public class AccuracyAffix : Affix
    {
        [SerializeField]
        protected int _value;
        [SerializeField]
        protected ValueType _valueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_value, _valueType, StatType.ACCURACY);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_value, _valueType, StatType.ACCURACY);
        }
    }
}