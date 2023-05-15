using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Affix/LuckAffix")]
    public class LuckAffix : Affix
    {
        [SerializeField]
        protected int _value;
        [SerializeField]
        protected ValueType _valueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_value, _valueType, StatType.LUCK);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_value, _valueType, StatType.LUCK);
        }
    }
}