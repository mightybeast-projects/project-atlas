using Managers;
using UnityEngine;

namespace MonoBehaviours.GameObjects.Enemy
{
    [RequireComponent(typeof(EnemyGraphicsController))]
    public class MoveTowardsPlayerOnAgroBehaviour : AggroScript
    {
        [SerializeField] 
        private WanderingScript _wanderingScript;
        [SerializeField] 
        private float _movementSpeed;

        private EnemyGraphicsController _graphicsController;
        private Vector3 _movementVector;
        
        private void Start()
        {
            _graphicsController = GetComponent<EnemyGraphicsController>();
        }

        private void FixedUpdate()
        {
            if(_isAggro){
                MoveTowardsPlayer();
                
                if(_wanderingScript != null)
                    _wanderingScript.enabled = false;
                
                _graphicsController.PlayWalkAnimation();
            }
            
            if(!_isAggro){
                if(_wanderingScript != null)
                    _wanderingScript.enabled = true;
            }
        }

        private void MoveTowardsPlayer()
        {
            GameObject player = GameManager.GetInstance().characterManager.characterBehaviour.gameObject;
            Vector3 playerPosition = player.transform.position;
            _movementVector = Vector3.MoveTowards(transform.position, playerPosition, _movementSpeed);
            
            Vector3 distance = playerPosition - transform.position;
            _graphicsController.FacePoint(distance);
            transform.position = _movementVector;
        }
    }
}