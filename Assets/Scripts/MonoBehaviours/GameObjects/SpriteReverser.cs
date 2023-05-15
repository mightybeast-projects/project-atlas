using UnityEngine;

namespace MonoBehaviours.GameObjects
{
    public class SpriteReverser : MonoBehaviour
    {
        [SerializeField] 
        private bool _facingRight = true;

        private Vector3 _previousPosition;
        private Vector3 _movement;

        private void FixedUpdate()
        {
            var currentPosition = transform.position;
            if(currentPosition != _previousPosition)
            {
                _movement = (currentPosition - _previousPosition).normalized;
                
                if (_movement.x < 0 && _facingRight)
                    ReverseSprite();
                else if (_movement.x > 0 && !_facingRight)
                    ReverseSprite();
            }
            
            _previousPosition = currentPosition;
        }
        
        private void ReverseSprite()
        {
            _facingRight = !_facingRight;
            Vector2 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}