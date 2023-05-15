using System.Collections;
using Managers;
using Managers.LocationManagers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MonoBehaviours.GameObjects.Enemy
{
    [RequireComponent(typeof(EnemyGraphicsController))]
    public class WanderingScript : MonoBehaviour
    {
        [SerializeField] 
        private int _movementTime = 2;
        [SerializeField] 
        private int _standingTime = 5;
        [SerializeField] 
        private int _movementSpeed = 1;
        
        private bool _isWandering;
        private bool _isMoving;
        private Vector3 _movementVector;
        private EnemyGraphicsController _graphicsController;

        private void Awake()
        {
            _graphicsController = GetComponent<EnemyGraphicsController>();
        }

        private void FixedUpdate()
        {
            if(!_isWandering)
                StartCoroutine(StartWandering());
            else if (_isMoving)
                Move();

            HandleGraphics();
        }

        private void OnDisable()
        {
            StopCoroutine(StartWandering());
        }

        private void HandleGraphics()
        {
            _graphicsController.FacePoint(_movementVector);
            
            if(_isMoving)
                _graphicsController.PlayWalkAnimation();
            else
                _graphicsController.FinishWalkAnimation();
        }

        private IEnumerator StartWandering()
        {
            _isWandering = true;

            _movementVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            _isMoving = true;

            yield return new WaitForSeconds(Random.Range(1f, (float)_movementTime + 1));
            _isMoving = false;
            yield return new WaitForSeconds(Random.Range(1f, (float)_standingTime + 1));

            _isWandering = false;
        }

        private void Move()
        {
            var position = transform.position;
            position += _movementVector * _movementSpeed;
            Vector3 afterMovement = position;

            afterMovement.x = Mathf.Clamp(afterMovement.x,
                0 + GameManager.worldOffset.x,
                LocationManager.locationWidth + GameManager.worldOffset.x - 32);
            afterMovement.y = Mathf.Clamp(afterMovement.y,
                0 + GameManager.worldOffset.y,
                LocationManager.locationHeight + GameManager.worldOffset.y - 32);

            position = afterMovement;

            transform.position = position;
        }
    }
}