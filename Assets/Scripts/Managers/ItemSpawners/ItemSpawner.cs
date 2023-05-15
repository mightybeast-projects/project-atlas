using System.Collections.Generic;
using Models;
using Models.ItemDataModel;
using MonoBehaviours.GameObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.ItemSpawners
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _locationContentPane;
        [SerializeField] private GameObject _itemShrinePrefab;

        protected Vector3 _centerTileSpawnPoint;
        protected Vector3 _spawnPoint;
        protected List<GameObject> _itemShrines;
        protected string _itemDescription;

        private GameObject _itemShrineGO;
        private ItemShrineBehaviour _shrineScript;
        private Text _shrineItemName;
        private SpriteRenderer _shrineItemSprite;
        private Text _shrineAffixDescription;

        protected void Start()
        {
            _itemShrines = new List<GameObject>();
        }

        protected void InstantiateNewItemShrine(Item item)
        {
            _itemShrineGO = Instantiate(_itemShrinePrefab, _spawnPoint, Quaternion.identity, _locationContentPane);
            
            GetItemShrineComponents();
            SetItemShrineProperties(item);
            
            _shrineAffixDescription.text = _itemDescription;
            _shrineScript.Initialize(item);

            _itemShrines.Add(_itemShrineGO);
        }
        
        public void GetCenterTileFromCreatedLocation(Location createdLocation)
        {
            _centerTileSpawnPoint = createdLocation.GetCenterTile().gameObject.transform.position;
        }
        
        public void RemoveShrines()
        {
            foreach (GameObject itemShrine in _itemShrines)
                Destroy(itemShrine);
        }
        
        private void GetItemShrineComponents()
        {
            _shrineItemName = _itemShrineGO.transform.Find("InformationPanel/ItemName").GetComponent<Text>();
            _shrineItemSprite = _itemShrineGO.transform.Find("ItemSprite").GetComponent<SpriteRenderer>();
            _shrineAffixDescription = _itemShrineGO.transform
                .Find("InformationPanel/AffixDescriptionPanel/AffixDescription")
                .GetComponent<Text>();
            _shrineScript = _itemShrineGO.GetComponent<ItemShrineBehaviour>();
        }

        private void SetItemShrineProperties(Item item)
        {
            _shrineItemName.text = item.name;
            _shrineItemSprite.sprite = item.sprite;
        }
    }
}