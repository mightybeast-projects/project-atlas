using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace Models.BuffModel
{
    public abstract class Buff : ScriptableObject
    {
        public int radius;
        public int amount;
        public int duration;
        public Color color;
        public Sprite powerUpSprite;

        public virtual void Apply(CharacterScript characterBehaviour){}
        public virtual void Reverse(CharacterScript character){}
    }
}