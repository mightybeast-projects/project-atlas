using Enums;
using EventSystem.Events;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace MonoBehaviours.GameObjects
{
    public class ExitScript : MonoBehaviour
    {
        public WorldSide exitSide => _exitSide;
        
        [SerializeField]
        private WorldSide _exitSide;
        [SerializeField]
        private LocationExitEvent _onLocationExitEvent;

        public void Initialize(WorldSide exit)
        {
            _exitSide = exit;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {    
            CharacterScript cs = other.gameObject.GetComponent<CharacterScript>();
            if(cs != null)
                _onLocationExitEvent.Raise(exitSide);
        }
    }
}
