using EventSystem.Events;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace Models.BuffModel
{
    [CreateAssetMenu(menuName = "Buff/HealthRegenBuff")]
    public class HealthRegenBuff : Buff
    {
        [SerializeField]
        private VoidEvent _onPlayerCurrentHealthChanged;
        
        public override void Apply(CharacterScript characterBehaviour)
        {
            characterBehaviour.character.ChangeCurrentHealthValue(amount);
            _onPlayerCurrentHealthChanged.Raise();
            //character.healthBar.UpdateValues(character.character.currentHealth, character.character.maxHealth);
        }
    }
}