using Enums;
using MonoBehaviours.GameObjects;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace Models.BuffModel
{
    [CreateAssetMenu(menuName = "Buff/AttackBuff")]
    public class AttackBuff : Buff
    {
        private bool _applied;
        
        public override void Apply(CharacterScript characterBehaviour)
        {
            if (!_applied)
            {
                characterBehaviour.character.GetCharacterStat(StatType.PHYSICAL_DAM).statValue.value += amount;
                _applied = true;
            }
        }

        public override void Reverse(CharacterScript character)
        {
            character.character.GetCharacterStat(StatType.PHYSICAL_DAM).statValue.value -= amount;
            _applied = false;
        }
    }
}