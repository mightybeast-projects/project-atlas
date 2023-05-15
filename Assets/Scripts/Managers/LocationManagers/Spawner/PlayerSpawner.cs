using Enums;
using MonoBehaviours.GameObjects.Player;
using UnityEngine;

namespace Managers.LocationManagers.Spawner
{
    public class PlayerSpawner : LocationSubManager
    {
        [SerializeField] 
        private CharacterScript _characterScript;
        
        internal void SpawnPlayer(WorldSide startSide)
        {
            var indexes = GetPlayerSpawnPoint(startSide);
            var tile = _currentLocation.grid[(int) indexes.x, (int) indexes.y];
            var tileGO = tile.gameObject;

            var playerGO = _characterScript.gameObject;
            playerGO.transform.position = tileGO.transform.position;
            if (startSide.Equals(WorldSide.PORTAL))
                playerGO.transform.position += new Vector3(16, 16, 0);
        }

        private Vector2 GetPlayerSpawnPoint(WorldSide startSide)
        {
            Vector2 indexes = new Vector2(0, 0);

            switch (startSide)
            {
                case WorldSide.PORTAL:
                    indexes.x = _currentLocation.grid.GetLength(0) / 2 - 1;
                    indexes.y = _currentLocation.grid.GetLength(1) / 2 - 1;
                    break;

                case WorldSide.NORTH:
                    indexes.x = _currentLocation.grid.GetLength(0) / 2 - 1;
                    indexes.y = _currentLocation.grid.GetLength(1) - 3;
                    break;

                case WorldSide.EAST:
                    indexes.x = _currentLocation.grid.GetLength(0) - 3;
                    indexes.y = _currentLocation.grid.GetLength(1) / 2 - 1;
                    break;

                case WorldSide.SOUTH:
                    indexes.x = _currentLocation.grid.GetLength(0) / 2 - 1;
                    indexes.y = 3;
                    break;

                case WorldSide.WEST:
                    indexes.x = 3;
                    indexes.y = _currentLocation.grid.GetLength(1) / 2 - 1;
                    break;
            }

            return indexes;
        }
    }
}