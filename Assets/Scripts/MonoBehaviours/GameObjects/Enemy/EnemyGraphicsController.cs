using UnityEngine;

namespace MonoBehaviours.GameObjects.Enemy
{
    public class EnemyGraphicsController : MonoBehaviour
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private GameObject _sprite;
        [SerializeField] 
        private bool _facingRight = true;
        
        private readonly int _isMoving = Animator.StringToHash("isMoving");
        private Vector3 _movement;

        public void FacePoint(Vector3 point)
        {
            if(point.x < 0 && _facingRight)
                ReverseSprite();
            else if (point.x > 0 && !_facingRight)
                ReverseSprite();
        }

        private void ReverseSprite()
        {
            _facingRight = !_facingRight;
            Vector2 theScale = _sprite.transform.localScale;
            theScale.x *= -1;
            _sprite.transform.localScale = theScale;
        }
        
        public void PlayWalkAnimation()
        {
            _animator.SetBool(_isMoving, true);
        }
    
        public void FinishWalkAnimation()
        {
            _animator.SetBool(_isMoving, false);
        }
    }
}