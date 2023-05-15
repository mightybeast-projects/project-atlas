using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Enemy.Projectiles
{
    public class NormalProjectileBehaviour : MonoBehaviour
    {
        public Vector3 target
        {
            set => _target = value;
        }
        
        [SerializeField] 
        private float _speed;
        
        private Vector3 _target;

        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed);
            if(transform.position == _target)
                Destroy(gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            CharacterScript characterScript = other.gameObject.GetComponent<CharacterScript>();
            if (characterScript != null && !characterScript.undamageable)
            {
                characterScript.GetHitFrom(gameObject, 10);
                Destroy(gameObject);
            }
        }
    }
}