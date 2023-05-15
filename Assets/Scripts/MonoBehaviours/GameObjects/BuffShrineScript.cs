using System.Collections;
using Interfaces;
using Models.BuffModel;
using MonoBehaviours.GameObjects.Player;
using NaughtyAttributes;
using UnityEngine;

namespace MonoBehaviours.GameObjects
{
    public class BuffShrineScript : MonoBehaviour, IInteractable
    {
        public Buff buff
        {
            get => _buff;
            set => _buff = value;
        }

        [SerializeField] 
        private GameObject _buffRadiusGO;
        [SerializeField] 
        private BoxCollider2D _boxCollider2D;
        [SerializeField] 
        private SpriteRenderer _powerUpSpriteRenderer;
        [SerializeField] 
        private SpriteRenderer _buffRadiusSpriteRenderer;
        [SerializeField][Expandable]
        private Buff _buff;
        
        private bool _onCooldown;

        private void Start()
        {
            _buffRadiusGO.SetActive(false);
            _powerUpSpriteRenderer.sprite = buff.powerUpSprite;
        }

        public void Interact()
        {
            _boxCollider2D.enabled = false;
            OpenShrine();
        }

        private void OpenShrine()
        {
            _buffRadiusGO.SetActive(true);
            _buffRadiusGO.transform.localScale = new Vector3(buff.radius, buff.radius, 1);
            _buffRadiusSpriteRenderer.color = buff.color;
            StartCoroutine(CloseShrine());
        }

        private IEnumerator CloseShrine()
        {
            yield return new WaitForSeconds(buff.duration);
            _buffRadiusGO.SetActive(false);
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            CharacterScript characterScript = other.gameObject.GetComponent<CharacterScript>();
            if (characterScript != null)
                StartCoroutine(ApplyBuffWithCd(characterScript));
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            CharacterScript characterScript = other.gameObject.GetComponent<CharacterScript>();
            if (characterScript == null) return;
            if (!_onCooldown)
                StartCoroutine(ApplyBuffWithCd(characterScript));
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            CharacterScript characterScript = other.gameObject.GetComponent<CharacterScript>();
            if (characterScript != null)
                buff.Reverse(characterScript);
        }

        private IEnumerator ApplyBuffWithCd(CharacterScript characterScript)
        {
            _onCooldown = true;
            buff.Apply(characterScript);
            yield return new WaitForSeconds(1f);
            _onCooldown = false;
        }
    }
}