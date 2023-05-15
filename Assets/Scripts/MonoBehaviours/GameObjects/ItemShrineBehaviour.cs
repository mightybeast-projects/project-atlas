using EventSystem.Events;
using Interfaces;
using Models.ItemDataModel;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace MonoBehaviours.GameObjects
{
    public class ItemShrineBehaviour : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private GameObject _descriptionPanel;
        [SerializeField]
        private VoidEvent _onItemPickedUpEvent;

        private Item _item;
        private CharacterScript _characterScript;
        private bool _isBossShrine;

        public void Initialize(Item item)
        {
            _item = item;
        }

        public void Interact()
        {
            _descriptionPanel.SetActive(true);
        }
        
        private void OnCollisionEnter2D(Collision2D coll)
        {
            _characterScript = coll.gameObject.GetComponent<CharacterScript>();
        }
        
        private void OnCollisionExit2D(Collision2D coll)
        {
            _characterScript = coll.gameObject.GetComponent<CharacterScript>();
            if (_characterScript != null){
                _descriptionPanel.SetActive(false);
            }
        }
        
        public virtual void PickupItem()
        {
            if(_item is IEquipable equipable)
                equipable.EquipOn(_characterScript.character);

            if(_onItemPickedUpEvent != null)
                _onItemPickedUpEvent.Raise();
        }
    }
}