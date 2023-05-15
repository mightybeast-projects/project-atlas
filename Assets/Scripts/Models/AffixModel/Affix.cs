using Enums;
using Models.GameObjectModel;
using Models.StatModel;
using NaughtyAttributes;
using UnityEngine;

namespace Models.AffixModel
{
    public abstract class Affix : ScriptableObject
    {
        [SerializeField][ResizableTextArea][DisableIf("NotEnabled")]
        private string _description;
        
        protected Character _character;

        protected void OnValidate()
        {
            _description = GetBasicDescription();
        }
        
        protected abstract void Apply();
        
        public abstract string GetBasicDescription();
        
        protected string GetValueDescription(int value, ValueType valueType, StatType statType)
        {
            string valueTypeString = valueType.ToString();
            string valueTypeS = valueTypeString == "PERCENT" ? "%" : "";
            string statTypeString = statType.ToString().ToLower().Replace("_", " ").Replace("dam", "damage");
            
            return "+ " + value + valueTypeS + " to " + statTypeString;
        }

        protected void AddAffixValueToStat(int value, ValueType valueType, StatType statType)
        {
            foreach (CharacterStat stat in _character.stats.statList)
            {
                if(stat.statType == statType)
                {
                    if(valueType == ValueType.FLAT)
                        stat.addedFlatAmount += value;
                    else
                        stat.multiplicativePercentAmount += value;
                }
            }
            
            _character.RecalculateStats();
        }

        public void ApplyTo(Character character)
        {
            _character = character;
            Apply();
        }
    }
}