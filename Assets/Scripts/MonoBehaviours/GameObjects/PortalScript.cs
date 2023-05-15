using EventSystem.Events;
using Interfaces;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.GameObjects
{
    public class PortalScript : MonoBehaviour, IInteractable
    {
        [SerializeField] 
        private Canvas _canvas;
        [SerializeField] 
        private Button _teleportButton;
        [SerializeField]
        private VoidEvent _onTeleportButtonPressed;
        [SerializeField]
        private VoidEvent _onTeleportInteracted;
        [SerializeField]
        private VoidEvent _onTeleportLeft;
        
        private void Start()
        {
            _teleportButton.onClick.AddListener(OpenPortalMap);
            _teleportButton.gameObject.SetActive(false);
            _canvas.worldCamera = Camera.main;
        }

        private void OnCollisionExit2D(Collision2D coll)
        {
            CharacterScript cs = coll.gameObject.GetComponent<CharacterScript>();
            if (cs == null) return;
            _teleportButton.gameObject.SetActive(false);
            _onTeleportLeft.Raise();
        }
        
        public void Interact()
        {
            _teleportButton.gameObject.SetActive(true);
            _onTeleportInteracted.Raise();
            gameObject.GetComponent<Animator>().enabled = true;
        }

        private void OpenPortalMap()
        {
            _onTeleportButtonPressed.Raise();
        }
    }
}