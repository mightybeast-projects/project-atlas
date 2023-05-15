using Enums;
using UnityEngine;

namespace Models.AffixModel
{
    [CreateAssetMenu(menuName = "Affix/SummonDamageAccuracyAffix")]
    public class SummonDamageAccuracyAffix : Affix
    {
        [SerializeField]
        private int _summonDamageValue;
        [SerializeField]
        private ValueType _summonDamageValueType;
        
        [SerializeField]
        private int _accuracyValue;
        [SerializeField]
        private ValueType _accuracyValueType;
        
        protected override void Apply()
        {
            AddAffixValueToStat(_summonDamageValue, _summonDamageValueType, StatType.SUMMON_DAM);
            AddAffixValueToStat(_accuracyValue, _accuracyValueType, StatType.ACCURACY);
        }

        public override string GetBasicDescription()
        {
            return GetValueDescription(_summonDamageValue, _summonDamageValueType, StatType.SUMMON_DAM) 
                   + "\n" + 
                   GetValueDescription(_accuracyValue, _accuracyValueType, StatType.ACCURACY);
        }
    }
}