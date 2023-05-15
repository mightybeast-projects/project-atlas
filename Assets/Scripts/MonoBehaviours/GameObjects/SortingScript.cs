using UnityEngine;

namespace MonoBehaviours.GameObjects
{
    public class SortingScript : MonoBehaviour
    {
        [SerializeField]
        private bool _staticObject;
        [SerializeField]
        private float _offset;
        
        private int _sortingOrderBase = 950;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        private void LateUpdate()
        {
            _spriteRenderer.sortingOrder = (int) (_sortingOrderBase - transform.position.y + _offset);
            if (_staticObject)
                Destroy(this);
        }
    }
}
