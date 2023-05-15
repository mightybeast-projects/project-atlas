using Managers;
using Managers.LocationManagers;
using Models.Value;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        public Vector3 movement => _movement;
        
        [SerializeField] private PlayerGraphicsController _playerGraphicsController;
        [SerializeField] private Vector3 _movement;
        [SerializeField] private FloatValue _movementSpeed;
        
        public void Move(Vector3 movementVector)
        {
            _playerGraphicsController.HandleCharacterSprite(movementVector);
            _playerGraphicsController.PlayWalkAnim(movementVector);
            _movement = movementVector;
            
            var currentPosition = transform.position;
            currentPosition += _movement * (_movementSpeed.value * 3) / 100;

            Vector3 afterMovement = currentPosition;
            afterMovement.x = Mathf.Clamp(afterMovement.x,
                0 + GameManager.worldOffset.x,
                LocationManager.locationWidth + GameManager.worldOffset.x - 32);
            afterMovement.y = Mathf.Clamp(afterMovement.y,
                0 + GameManager.worldOffset.y,
                LocationManager.locationHeight + GameManager.worldOffset.y - 32);
            currentPosition = afterMovement;
            
            transform.position = currentPosition;
        }
    }
}