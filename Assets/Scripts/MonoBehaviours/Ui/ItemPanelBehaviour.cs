using Models;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.Ui
{
    public class ItemPanelBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Inventory _inventory;
        [SerializeField]
        private GameObject _panelItemPrefab;
        
        private float _smallPanelItemScale = 0.5f;
        private float _largePanelItemScale = 1f;
        private float _currentPanelItemScale = 1f;
        private int _largeTextSize = 10;
        private int _smallTextSize = 20;
        private int _currentTextSize = 10;
        private int _itemCountThreshold = 7;

        private void Start()
        {
            UpdatePanel();
        }

        public void UpdatePanel()
        {
            ChooseItemAndTextSize();
            
            for(int i = 0; i < transform.childCount; i++)
                Destroy(transform.GetChild(i).gameObject);

            foreach (var inventorySlot in _inventory.itemSlots)
                UpdatePanelItemVisuals(inventorySlot);
        }

        private void ChooseItemAndTextSize()
        {
            if (_inventory.itemSlots.Count >= _itemCountThreshold)
            {
                _currentTextSize = _smallTextSize;
                _currentPanelItemScale = _smallPanelItemScale;
            }
            else
            {
                _currentTextSize = _largeTextSize;
                _currentPanelItemScale = _largePanelItemScale;
            }
        }

        private void UpdatePanelItemVisuals(Inventory.InventorySlot inventorySlot)
        {
            Sprite equipSprite = inventorySlot.item.sprite;
            GameObject panelItem = Instantiate(_panelItemPrefab, transform);
            Image image = panelItem.GetComponent<Image>();
            Text amountText = panelItem.transform.GetChild(0).gameObject.GetComponent<Text>();

            panelItem.transform.localScale = new Vector3(_currentPanelItemScale, _currentPanelItemScale, 0);
            image.sprite = equipSprite;
            amountText.text = "x" + inventorySlot.amount;
            amountText.fontSize = _currentTextSize;
        }
    }
}