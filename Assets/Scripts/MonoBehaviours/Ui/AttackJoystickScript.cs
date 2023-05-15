using MonoBehaviours.GameObjects;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;
#pragma warning disable 414

namespace MonoBehaviours.Ui
{
    public class AttackJoystickScript : MonoBehaviour
    {
        [SerializeField]
        private PlayerGraphicsController _playerGraphicsController;

        private Joystick _joystick;

        private bool _heldDown;
        private void Start()
        {
            _joystick = transform.GetComponent<Joystick>();
        }

        private void FixedUpdate()
        {
            Vector3 movement = new Vector3(_joystick.Horizontal, _joystick.Vertical, 0);
            
            _playerGraphicsController.SwingWeapon(movement);
        }

        public void HeldDown()
        {
            _heldDown = true;
            _playerGraphicsController.swingingWeapon = true;
            _playerGraphicsController.PlayAttackAnim();
        }

        public void HeldUp()
        {
            _heldDown = false;
            _playerGraphicsController.swingingWeapon = false;
            _playerGraphicsController.FinishAttackAnim();
        }
    }
}
