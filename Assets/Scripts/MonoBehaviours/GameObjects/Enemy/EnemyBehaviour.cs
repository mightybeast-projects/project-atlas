using EventSystem.Events;
using Interfaces;
using Models;
using MonoBehaviours.Ui.Display;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Enemy
{
    public class EnemyBehaviour : MonoBehaviour, IHittable
    {
        [SerializeField]
        protected EnemyBarBehaviour _healthEnemyBar;
        [SerializeField]
        private int _maxHealth;
        [SerializeField]
        protected VoidEvent _onEnemyDeath;

        private float _currentDifficultyScale = 1f;
        protected int _currentHealth;
        protected Location _location;
        
        protected virtual void Start()
        {
            ApplyDifficultyScale();

            _currentHealth = _maxHealth;
            
            _healthEnemyBar.UpdateValues(_currentHealth, _maxHealth);
        }

        private void FixedUpdate()
        {
            CheckHealth();
        }
        
        public void Initialize(Location location, VoidEvent onEnemyDeathEvent, float difficultyMultiplier)
        {
            _location = location;
            _onEnemyDeath = onEnemyDeathEvent;
            _currentDifficultyScale = difficultyMultiplier;
        }
        
        public void GetHitFrom(GameObject hitSourceGameObject, int amount)
        {
            _currentHealth -= amount;
            _healthEnemyBar.UpdateValues(_currentHealth, _maxHealth);
            
            GameUtilities.PlayHitSequence(hitSourceGameObject, gameObject, this);
        }

        public void SetHealthBar(EnemyBarBehaviour healthEnemyBar)
        {
            _healthEnemyBar = healthEnemyBar;
            _healthEnemyBar.UpdateValues(_currentHealth, _maxHealth);
        }

        protected virtual void CheckHealth()
        {
            if (_currentHealth > 0) return;
            
            Destroy(gameObject);
            _location.enemies.Remove(this);
            _onEnemyDeath.Raise();
        }
        
        private void ApplyDifficultyScale()
        {
            DamageOnCollisionBehaviour collisionScript = GetComponent<DamageOnCollisionBehaviour>();
            if (collisionScript != null)
            {
                int damageAmount = collisionScript.damageAmount;
                int newDamageAmount = (int) (damageAmount * _currentDifficultyScale);
                collisionScript.damageAmount = newDamageAmount;
            }

            _maxHealth = (int) (_maxHealth * _currentDifficultyScale);
        }
    }
}
