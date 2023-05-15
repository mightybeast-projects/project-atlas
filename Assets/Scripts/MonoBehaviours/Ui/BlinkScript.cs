using System.Collections;
using MonoBehaviours.GameObjects;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class BlinkScript : MonoBehaviour
    {
        [SerializeField]
        private CharacterScript _characterScript;
        [SerializeField]
        private PlayerMovementController _playerMovementController;
        [SerializeField]
        public int _blinkDistanceMultiplier = 60;
        [SerializeField]
        public int _cooldownTime = 2;
        [SerializeField]
        public bool _onCooldown;
        
        public void Blink()
        {
            if (!_onCooldown)
                BlinkForward();
        }

        private void BlinkForward()
        {
            Vector3 blinkVector = _playerMovementController.movement;
            float blinkDistance = blinkVector.magnitude;
            var characterScriptTransform = _characterScript.transform;
            
            Vector3 currentCharacterPosition = characterScriptTransform.localPosition;

            Vector3 newCharacterPosition = currentCharacterPosition + new Vector3(
                blinkVector.x * blinkDistance * _blinkDistanceMultiplier,
                blinkVector.y * blinkDistance * _blinkDistanceMultiplier,
                0);
            characterScriptTransform.localPosition = newCharacterPosition;
            
            StartCoroutine(BeginCooldown());
        }

        private IEnumerator BeginCooldown()
        {
            _onCooldown = true;
            yield return new WaitForSeconds(_cooldownTime);
            _onCooldown = false;
        }
    }
}