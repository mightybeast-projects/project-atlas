using EventSystem.Events;
using Interfaces;
using Models.GameObjectModel;
using Models.Value;
using NaughtyAttributes;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Player
{
    public class CharacterScript : MonoBehaviour, IHittable
    {
        public bool undamageable { get; set; }
        public IntValue classPoints => _classPoints;
        public Character character => _character;
        
        [SerializeField] private Character _character;
        
        [SerializeField] private PlayerGraphicsController _playerGraphicsController;
        
        [SerializeField] private IntValue _lvlValue;
        [SerializeField] private IntValue _classPoints;
        [SerializeField] private FloatValue _currentExperience;
        [SerializeField] private FloatValue _experienceThreshold;

        [SerializeField] private VoidEvent _onCharacterLevelUp;
        [SerializeField] private VoidEvent _onPlayerIsHit;

        private void Start()
        {
            _character.RecalculateStats();
        }

        public void GetHitFrom(GameObject hitSourceGameObject, int amount)
        {
            character.ChangeCurrentHealthValue(-amount);

            GameUtilities.PlayHitSequence(hitSourceGameObject, gameObject, this);
            MakeUndamageable();
            
            _onPlayerIsHit.Raise();
        }
        
        public void ResetData()
        {
            _lvlValue.value = _lvlValue.baseValue;
            _classPoints.value = _classPoints.baseValue;
            _currentExperience.value = _currentExperience.baseValue;
            _experienceThreshold.value = _experienceThreshold.baseValue;
        }

        public void HealUp(int value)
        {
            _character.ChangeCurrentHealthValue(value);
        }

        private void MakeUndamageable()
        {
            undamageable = true;

            StartCoroutine(_playerGraphicsController.BlinkCharacterSprite());

            undamageable = false;
        }

        public void AddExperience(int experiencePool)
        {
            _currentExperience.value += experiencePool;
            
            if(_currentExperience.value >= _experienceThreshold.value)
                LevelUp();
        }

        [Button]
        private void LevelUp()
        {
            _classPoints.value++;
            _lvlValue.value++;
            _currentExperience.value -= _experienceThreshold.value;
            _experienceThreshold.value += 20;

            _onCharacterLevelUp.Raise();
        }
    }
}
