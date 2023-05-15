using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Enemy
{
    public class DamageOnCollisionBehaviour : MonoBehaviour
    {
        public int damageAmount { get; set; } = 10;

        private CharacterScript _characterScript;

        private void OnCollisionEnter2D(Collision2D other)
        {
            DamagePlayer(other);
        }
        
        private void OnCollisionStay2D(Collision2D other)
        {
            DamagePlayer(other);
        }
        
        private void DamagePlayer(Collision2D other)
        {
            _characterScript = other.gameObject.GetComponent<CharacterScript>();
            if (_characterScript != null && !_characterScript.undamageable)
                _characterScript.GetHitFrom(gameObject, damageAmount);
        }
    }
}