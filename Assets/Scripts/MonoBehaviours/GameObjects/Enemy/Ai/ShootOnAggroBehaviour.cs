using System.Collections;
using Managers;
using MonoBehaviours.GameObjects.Enemy.Projectiles;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Enemy
{
    [RequireComponent(typeof(EnemyGraphicsController))]
    public class ShootOnAggroBehaviour : AggroScript
    {
        [SerializeField]
        private WanderingScript _wanderingScript;
        [SerializeField] 
        private GameObject _projectilePrefab;
        [SerializeField]
        private int _projectileCount;
        [SerializeField]
        private float _projectileWaveInterval = 1.5f;
        [SerializeField]
        private float _projectileShootInterval;

        private bool _canShoot = true;
        private EnemyGraphicsController _graphicsController;
        private GameObject _playerGO;
        private Vector3 _target;
        
        private void Awake()
        {
            _graphicsController = GetComponent<EnemyGraphicsController>();
            _playerGO = GameManager.GetInstance().characterManager.characterBehaviour.gameObject;
        }

        private void FixedUpdate()
        {
            if(_isAggro)
            {
                if(_wanderingScript != null)
                    _wanderingScript.enabled = false;
                
                FacePlayer();
                
                if(_canShoot)
                    StartCoroutine(ShootProjectiles());
            }

            if (_isAggro) return;
            
            if(_wanderingScript != null)
                _wanderingScript.enabled = true;

        }

        private void FacePlayer()
        {
            Vector3 playerPosition = _playerGO.transform.position;
            Vector3 distance = playerPosition - transform.position;
        
            _graphicsController.FacePoint(distance);
        }

        private IEnumerator ShootProjectiles()
        {    
            _canShoot = false;
            
            for(int i = 0; i < _projectileCount; i++)
            {
                _target = _playerGO.transform.position;
            
                GameObject projectileGO = Instantiate(_projectilePrefab, transform.parent);
                projectileGO.transform.position = transform.position;
                projectileGO.GetComponent<NormalProjectileBehaviour>().target = _target;
                
                yield return new WaitForSeconds(_projectileShootInterval);
            }

            yield return new WaitForSeconds(_projectileWaveInterval);
            _canShoot = true;
        }
    }
}