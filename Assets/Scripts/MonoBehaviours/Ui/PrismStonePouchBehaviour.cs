using System.Collections.Generic;
using Models;
using UnityEngine;

namespace MonoBehaviours.Ui
{
    public class PrismStonePouchBehaviour : MonoBehaviour
    {
        [SerializeField]
        private Inventory _prismStonePouch;
        [SerializeField]
        private List<PrismStonePanelItemBehaviour> _prismStonePanelItems;

        private void Start()
        {
            UpdatePanel();
        }

        public void UpdatePanel()
        {
            foreach (PrismStonePanelItemBehaviour _panelItem in _prismStonePanelItems)
                _panelItem.gameObject.SetActive(false);

            foreach (Inventory.InventorySlot inventorySlot in _prismStonePouch.itemSlots)
            {
                string prismStoneName = inventorySlot.item.name;
                foreach (PrismStonePanelItemBehaviour _panelItem in _prismStonePanelItems)
                    if(_panelItem.prismStone.name == prismStoneName && !_panelItem.gameObject.activeSelf)
                        _panelItem.gameObject.SetActive(true);
            }
        }
    }
}