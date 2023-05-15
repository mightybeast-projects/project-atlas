using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class MovementJoystickScript : MonoBehaviour
    {
        [SerializeField]
        private PlayerMovementController _playerMovementController;
        
        private Joystick _joystick;

        private void Start()
        {
            _joystick = FindObjectOfType<Joystick>();
        }
    
        private void Update()
        {
            //WASD movement
            float horizontal = Input.GetAxis("Horizontal"),
                vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal, vertical, 0);
            
            //Joystick movement
            if(movement.magnitude == 0)
            {
                movement = new Vector3(_joystick.Horizontal,
                    _joystick.Vertical,
                    0);
            }
        
            _playerMovementController.Move(movement);
        }
    }
}
