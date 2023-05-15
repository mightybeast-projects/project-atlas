using System.Collections;
using Managers;
using Managers.LocationManagers;
using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class CameraScript : MonoBehaviour
    {
        [SerializeField]
        private Transform _playerTransform;
        [SerializeField]
        private FixedJoystick _attackJoystick;
        [SerializeField]
        private float _movementLerpTime = 0.08f;
        [SerializeField]
        private float _attackLerpTime = 0.08f;
        
        private Vector3 _movement;
        private Vector3 _attackJoystickMovement;
        private int _viewRadius = 20;
        
        private void Start()
        {
            var playerPosition = _playerTransform.position;
            
            _movement = playerPosition;
            transform.position = playerPosition;
        }
    
        private void LateUpdate()
        {
            _movement = _playerTransform.position;
            _movement.z = 0;
            _movement.x = Mathf.Clamp(_movement.x, 0, LocationManager.locationWidth + GameManager.worldOffset.x * 2 - 32);
            _movement.y = Mathf.Clamp(_movement.y, 0, LocationManager.locationHeight + GameManager.worldOffset.y * 2 - 32);
            Vector3 smoothMovement = Vector3.Lerp(transform.position, _movement, _movementLerpTime);
            transform.position = smoothMovement;

            MoveCamera();
        }
        
        public void ShakeCameraAfterPlayerIsHit()
        {
            StartCoroutine(Shake(0.1f, 3f));
        }

        public IEnumerator Shake(float duration, float magnitude)
        {
            Transform parent = transform.parent;
            Vector3 originalPos = parent.transform.localPosition;

            float elapsed = 0.0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                parent.position = new Vector3(x, y, originalPos.z);

                elapsed += Time.deltaTime;

                yield return null;
            }

            parent.position = originalPos;
        }

        private void MoveCamera()
        {
            _attackJoystickMovement = new Vector3(_attackJoystick.Horizontal, _attackJoystick.Vertical, 0);
            Vector3 cameraMovement = _attackJoystickMovement * _viewRadius;

            var cameraPosition = transform.position;
            Vector3 positionToMove = cameraPosition + cameraMovement;

            Vector3 smoothMovement = Vector3.Lerp(cameraPosition, positionToMove, _attackLerpTime);
            smoothMovement.x = Mathf.Clamp(smoothMovement.x, 0, LocationManager.locationWidth + GameManager.worldOffset.x * 2 - 32);
            smoothMovement.y = Mathf.Clamp(smoothMovement.y, 0, LocationManager.locationHeight + GameManager.worldOffset.y * 2 - 32);
            cameraPosition = smoothMovement;
            
            transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -1);
        }
    }
}
