using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/DeflectAffix")]
    public class DeflectAffix : Affix
    {
        [SerializeField]
        protected int _value;
        [SerializeField]
        protected ValueType _valueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_value, _valueType, StatType.DEFLECT);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_value, _valueType, StatType.DEFLECT);
        }
    }
}