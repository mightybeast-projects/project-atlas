using System.Collections;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Player
{
    public class PlayerGraphicsController : MonoBehaviour
    {
        public bool swingingWeapon { get; set; }

        [SerializeField] private Animator _characterAnimator;
        [SerializeField] private Animator _weaponAnimator;
        [SerializeField] private Transform _characterSpriteTransform;
        [SerializeField] private Transform _weaponHandTransform;
        [SerializeField] private SpriteRenderer _characterSpriteRenderer;
        [SerializeField] private Material _hitMaterial;
        
        private bool _characterFacingRight = true;
        private bool _weaponFacingRight = true;

        private readonly int _attack = Animator.StringToHash("attack");
        private readonly int _speed = Animator.StringToHash("speed");

        private Vector3 _movement;
        private Material _defaultMaterial;

        private void Start()
        {
            _defaultMaterial = _characterSpriteRenderer.material;
        }
        
        public void HandleCharacterSprite(Vector3 point)
        {
            if(!swingingWeapon)
                FaceWeaponToPoint(point);

            FaceCharacterToPoint(point);
        }
        
        public void SwingWeapon(Vector3 movement)
        {
            if(swingingWeapon)
                HandleCharacterSprite(movement);
            
            FaceWeaponToPoint(movement);
            
            RotateHand(movement);
        }
        
        public IEnumerator BlinkCharacterSprite()
        {
            _characterSpriteRenderer.material = _hitMaterial;
            yield return new WaitForSeconds(0.1f);
            _characterSpriteRenderer.material = _defaultMaterial;
            yield return new WaitForSeconds(0.1f);
            _characterSpriteRenderer.material = _hitMaterial;
            yield return new WaitForSeconds(0.1f);
            _characterSpriteRenderer.material = _defaultMaterial;
            yield return new WaitForSeconds(0.1f);
        }

        public void PlayAttackAnim()
        {
            _weaponAnimator.SetBool(_attack, true);
        }

        public void FinishAttackAnim()
        {
            _weaponAnimator.SetBool(_attack, false);
        }

        public void PlayWalkAnim(Vector3 movement)
        {
            _characterAnimator.SetFloat(_speed, movement.magnitude);
        }
        
        private void RotateHand(Vector3 movement)
        {
            Vector3 currentAngle = _weaponHandTransform.eulerAngles;
            
            if (movement.x >= 0)
                _weaponHandTransform.eulerAngles = new Vector3(currentAngle.x, currentAngle.y, 90 * movement.y);
            else
                _weaponHandTransform.eulerAngles = new Vector3(currentAngle.x, currentAngle.y, 90 * movement.y * -1);
        }
        
        private void FaceCharacterToPoint(Vector3 point)
        {
            if (point.x < 0 && _characterFacingRight)
                ReverseCharacterTransform();
            else if (point.x > 0 && !_characterFacingRight)
                ReverseCharacterTransform();
        }

        private void FaceWeaponToPoint(Vector3 movement)
        {
            if (movement.x < 0 && _weaponFacingRight)
                ReverseWeaponTransform();
            else if (movement.x > 0 && !_weaponFacingRight)
                ReverseWeaponTransform();
        }
        
        private void ReverseWeaponTransform()
        {
            _weaponFacingRight = !_weaponFacingRight;
            Vector2 theScale = _weaponHandTransform.localScale;
            theScale.x *= -1;
            _weaponHandTransform.localScale = theScale;
        }
        
        private void ReverseCharacterTransform()
        {
            _characterFacingRight = !_characterFacingRight;
            Vector2 theScale = _characterSpriteTransform.localScale;
            theScale.x *= -1;
            _characterSpriteTransform.localScale = theScale;
        }
    }
}