using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace Models.BuffModel
{
    [CreateAssetMenu(menuName = "Buff/MovementBuff")]
    public class MovementBuff : Buff
    {
        private bool _applied;
        
        public override void Apply(CharacterScript characterBehaviour)
        {
            if (!_applied)
            {
                //characterBehaviour.playerMovementController.movementSpeed += amount;
                _applied = true;
            }
        }

        public override void Reverse(CharacterScript character)
        {
            //character.playerMovementController.movementSpeed -= amount;
            _applied = false;
        }
    }
}