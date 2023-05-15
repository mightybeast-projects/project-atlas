using Enums;
using Models.GameObjectModel;
using MonoBehaviours.GameObjects;
using MonoBehaviours.GameObjects.Enemy;
using UnityEngine;

namespace Managers.LocationManagers.Spawner
{
    public class NPCSpawner: LocationSubManager
    {
        [SerializeField] 
        private GameObject _npcPrefab;

        internal void SpawnNPCs()
        {
            SpawnGuardNPCs();
            //SpawnStorageNPC();
            //SpawnElderNPC();
        }

        private void SpawnGuardNPCs()
        {
            for (var x = 0; x < _currentLocation.grid.GetLength(0); x++)
            for (var y = 0; y < _currentLocation.grid.GetLength(1); y++)
            {
                var tile = _currentLocation.grid[x, y];
                var exitScript = tile.gameObject.GetComponent<ExitScript>();
                if (exitScript != null)
                {
                    SpawnGuardNPCs(exitScript, tile);
                }
            }
        }

        private void SpawnGuardNPCs(ExitScript exitScript, Tile tile)
        {
            Vector3 firstPoint,
                secondPoint,
                firstScale = new Vector3(1, 1, 1),
                secondScale = new Vector3(1, 1, 1);
            var exitSide = exitScript.exitSide;
    
            if (exitSide == WorldSide.NORTH || exitSide == WorldSide.SOUTH)
            {
                var position = tile.gameObject.transform.position;
                firstPoint = new Vector3(position.x - 48, position.y, 1);
                secondPoint = new Vector3(position.x + 48, position.y, 1);
                secondScale = new Vector3(-1, 1, 1);
            }
            else
            {
                var position = tile.gameObject.transform.position;
                firstPoint = new Vector3(position.x, position.y - 48, 1);
                secondPoint = new Vector3(position.x, position.y + 48, 1);
                if (exitSide == WorldSide.EAST)
                {
                    firstScale = new Vector3(-1, 1, 1);
                    secondScale = new Vector3(-1, 1, 1);
                }
            }

            InstantiateGuardNPC(firstPoint, firstScale);
            InstantiateGuardNPC(secondPoint, secondScale);
        }

        private void InstantiateGuardNPC(Vector3 position, Vector3 scale)
        {
            var newGuardGO = Instantiate(_npcPrefab, _contentPane);
            newGuardGO.transform.position = position;
            newGuardGO.transform.localScale = scale;
        }

        private void SpawnStorageNPC()
        {
            var storageNPCGO = InstantiateStorageNPC();
            DisableNPCChildes(storageNPCGO);
        }

        private GameObject InstantiateStorageNPC()
        {
            var storageGO = Instantiate(_npcPrefab, _contentPane);
            storageGO.transform.position = new Vector3(250 + GameManager.worldOffset.x, 850 + GameManager.worldOffset.y, 1);
            var storageRenderer = storageGO.GetComponent<SpriteRenderer>();
            var storageSprite = Resources.Load<Sprite>("Sprites/World/NPCs/storage_keeper");
            storageRenderer.sprite = storageSprite;
            var storageGOShadow = storageGO.transform.GetChild(2).gameObject;
            RectTransform shadowTransform = storageGOShadow.GetComponent<RectTransform>();
            shadowTransform.rect.Set(0, -14, 32, 8);
            return storageGO;
        }

        private static void DisableNPCChildes(GameObject npcGameObject)
        {
            for (var i = 0; i < npcGameObject.transform.childCount - 1; i++)
            {
                var child = npcGameObject.transform.GetChild(i).gameObject;
                child.SetActive(false);
            }
        }

        private void SpawnElderNPC()
        {
            var elderGO = InstantiateElderNPC();
            DisableNPCChildes(elderGO);
            AddElderNPCLogic(elderGO);
        }

        private void AddElderNPCLogic(GameObject elderGO)
        {
            elderGO.AddComponent<WanderingScript>();
            elderGO.AddComponent<SpriteReverser>();
            elderGO.AddComponent<SortingScript>();
            var shadowGO = elderGO.transform.GetChild(2).gameObject;
            var shadowGOPosition = shadowGO.transform.position;
            shadowGOPosition = new Vector3(shadowGOPosition.x, shadowGOPosition.y - 2, shadowGOPosition.z);
            shadowGO.transform.position = shadowGOPosition;
        }

        private GameObject InstantiateElderNPC()
        {
            var portalPosition = new Vector3(_currentLocation.grid.GetLength(0) / 2 - 1, 
                _currentLocation.grid.GetLength(1) / 2 - 1, 
                1);
            var elderGO = Instantiate(_npcPrefab, _contentPane);
            elderGO.transform.position = portalPosition + new Vector3(-GameManager.worldOffset.x, -GameManager.worldOffset.y, 0);
            var elderRenderer = elderGO.GetComponent<SpriteRenderer>();
            var elderSprite = Resources.Load<Sprite>("Sprites/World/NPCs/elder");
            elderRenderer.sprite = elderSprite;
            return elderGO;
        }
    }
}