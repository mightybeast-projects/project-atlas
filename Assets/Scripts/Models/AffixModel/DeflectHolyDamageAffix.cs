using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(fileName = "FILENAME", menuName = "Affix/DeflectHolyDamageAffix")]
    public class DeflectHolyDamageAffix : Affix
    {
        [SerializeField]
        private int _deflectValue;
        [SerializeField]
        private ValueType _deflectValueType;
        
        [SerializeField]
        private int _holyDamageValue;
        [SerializeField]
        private ValueType _holyDamageValueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_deflectValue, _deflectValueType, StatType.DEFLECT);
            AddAffixValueToStat(_holyDamageValue, _holyDamageValueType, StatType.HOLY_DAM);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_deflectValue, _deflectValueType, StatType.DEFLECT) 
                   + "\n" + 
                   GetValueDescription(_holyDamageValue, _holyDamageValueType, StatType.HOLY_DAM);
        }
    }
}