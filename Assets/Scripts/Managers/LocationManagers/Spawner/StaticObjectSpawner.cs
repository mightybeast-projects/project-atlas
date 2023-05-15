using System.Collections.Generic;
using Enums;
using Models.BuffModel;
using Models.GameObjectModel;
using MonoBehaviours.GameObjects;
using MonoBehaviours.Ui;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers.LocationManagers.Spawner
{
    public class StaticObjectSpawner: LocationSubManager
    {
        [SerializeField]
        private GameObject _portalPrefab, _buffShrinePrefab;
        [SerializeField][Range(0, 10)]
        private int _shrineCounter;
        [SerializeField]
        private List<Buff> _buffs;

        private List<GameObject> _buffShrines;

        internal void SpawnPortal(MapNodeBehaviour mapNode)
        {
            var tile = _currentLocation.GetCenterTile();
            CreateNewPortal(mapNode, tile);
        }
        
        public void RemoveBuffShrines()
        {
            foreach (GameObject buffShrine in _buffShrines)
                Destroy(buffShrine);
        
            _buffShrines.Clear();
        }

        private void CreateNewPortal(MapNodeBehaviour mapNode, Tile tile)
        {
            var portalGO = Instantiate(_portalPrefab, _contentPane);
            portalGO.transform.position = tile.gameObject.transform.position + new Vector3(16, 16, 0);
            if(mapNode.mapNodeStatus == MapNodeStatus.UNLOCKED_PORTAL)
                portalGO.GetComponent<Animator>().enabled = true;
            SpriteRenderer decorationSpriteRenderer = portalGO.transform.GetChild(1).GetComponent<SpriteRenderer>();

            string biomeName = _currentLocation.biome.ToString().ToLower();
            var path = "Sprites/World/Portals/" + biomeName + "_portal_decoration";
            var portalDecorationSprite = Resources.Load<Sprite>(path);
        
            decorationSpriteRenderer.sprite = portalDecorationSprite;
        }
    
        internal void SpawnBuffShrines()
        {
            _buffShrines = new List<GameObject>();
            
            if(_buffs.Count > 0)
            {
                for (int i = 0; i < _shrineCounter; i++)
                    InitializeNewBuffShrine();
            }
        }

        private void InitializeNewBuffShrine()
        {
            Buff buff = _buffs[Random.Range(0, _buffs.Count)];
            var shrineGO = Instantiate(_buffShrinePrefab, _contentPane);
            var x = Random.Range(0, _currentLocation.tWidth - 1);
            var y = Random.Range(0, _currentLocation.tHeight - 1);
            var tileGO = _currentLocation.grid[x, y].gameObject;
            shrineGO.transform.position = tileGO.transform.position;
            shrineGO.GetComponent<BuffShrineScript>().buff = buff;
            _buffShrines.Add(shrineGO);
        }
    }
}