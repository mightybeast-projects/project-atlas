using System;

namespace MonoBehaviours.GameObjects.Enemy
{
    public class BossBehaviour : EnemyBehaviour
    {
        private void OnDestroy()
        {
            _healthEnemyBar.gameObject.SetActive(false);
        }

        protected override void CheckHealth()
        {
            if (_currentHealth > 0) return;
            
            Destroy(gameObject);
            try { _location.enemies.Remove(this); }
            catch (Exception) { }
            
            _onEnemyDeath.Raise();
        }
    }
}