using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/ChaosElementalAffix")]
    public class ChaosElementalAffix : Affix
    {
        [SerializeField]
        private int _chaosDamageValue;
        [SerializeField]
        private ValueType _chaosDamageValueType;
        
        [SerializeField]
        private int _elementalDamageValue;
        [SerializeField]
        private ValueType _elementalDamageValueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_chaosDamageValue, _chaosDamageValueType, StatType.CHAOS_DAM);
            AddAffixValueToStat(_elementalDamageValue, _elementalDamageValueType, StatType.ELEMENTAL_DAM);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_chaosDamageValue, _chaosDamageValueType, StatType.CHAOS_DAM) 
                   + "\n" + 
                   GetValueDescription(_elementalDamageValue, _elementalDamageValueType, StatType.ELEMENTAL_DAM);
        }
    }
}