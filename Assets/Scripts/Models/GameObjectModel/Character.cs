using System.Linq;
using Enums;
using EventSystem.Events;
using Models.StatModel;
using Models.Value;
using UnityEngine;

namespace Models.GameObjectModel
{
    [CreateAssetMenu(menuName = "Player/Character")]
    public class Character : ScriptableObject 
    {
        public Inventory inventory => _inventory;
        public Inventory prismStonePouch => _prismStonePouch;
        public CharacterStats stats => _stats;
        
        [SerializeField] private Inventory _inventory;
        [SerializeField] private Inventory _prismStonePouch;
        [SerializeField] private CharacterStats _stats;
        
        [SerializeField] private FloatValue _maxHealth;
        [SerializeField] private FloatValue _currentHealth;
        
        [SerializeField] private VoidEvent _onPlayerCurrentHealthChanged;
        [SerializeField] private VoidEvent _onPlayerStatsChanged;
        [SerializeField] private VoidEvent _onPlayerDied;

        public void ChangeCurrentHealthValue(float value)
        {
            _currentHealth.value += value;
            
            if(_currentHealth.value < 0) _currentHealth.value = 0;
            if(_currentHealth.value > _maxHealth.value) _currentHealth.value = _maxHealth.value;

            _onPlayerCurrentHealthChanged.Raise();
            
            if(_currentHealth.value == 0)
                _onPlayerDied.Raise();
        }

        public CharacterStat GetCharacterStat(StatType statType)
        {
            return stats.statList.FirstOrDefault(stat => stat.statType == statType);
        }
    
        public void RecalculateStats()
        {
            foreach (CharacterStat stat in stats.statList)
                stat.RecalculateStat();
        
            UpdateStatValues();
        }
        
        public void ResetHealth()
        {
            _currentHealth.value = _currentHealth.baseValue;
            _maxHealth.value = _maxHealth.baseValue;
        }
    
        private void UpdateStatValues()
        {
            CharacterStat currentStat = GetCharacterStat(StatType.MAXIMUM_HEALTH);
            _maxHealth.value = (int) currentStat.statValue.value;
            
            _onPlayerStatsChanged.Raise();
        }
    }
}