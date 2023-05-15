using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace Models.BuffModel
{
    [CreateAssetMenu(menuName = "Buff/ImmortalityBuff")]
    public class ImmortalityBuff : Buff
    {
        private bool _applied;
        
        public override void Apply(CharacterScript characterBehaviour)
        {
            if (!_applied)
            {
                characterBehaviour.undamageable = true;
                _applied = true;
            }
        }

        public override void Reverse(CharacterScript character)
        {
            character.undamageable = false;
            _applied = false;
        }
    }
}