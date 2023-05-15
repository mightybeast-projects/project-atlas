using Enums;
using MonoBehaviours.GameObjects;
using UnityEngine;

namespace Managers.LocationManagers
{
    public class ExitsManager : LocationSubManager
    {
        [SerializeField]
        private GameObject _exitTilePrefab;
        
        private Vector2 _exitTileIndexes;
        private WorldSide _exitTileWorldSide;
        
        public void AddExits()
        {
            foreach (var exitSide in _currentLocation.exitSides)
                CreateNewExitTile(exitSide);
        }
        
        private void CreateNewExitTile(WorldSide exitSide)
        {
            _exitTileWorldSide = exitSide;
            ChooseExitIndexes(_exitTileWorldSide);
            InstantiateExitTile();
        }
        
        private void ChooseExitIndexes(WorldSide exitSide)
        {
            switch (exitSide)
            {
                case WorldSide.NORTH:
                    _exitTileIndexes.x = _currentLocation.grid.GetLength(0) / 2;
                    _exitTileIndexes.y = _currentLocation.grid.GetLength(1) - 1;
                    break;

                case WorldSide.EAST:
                    _exitTileIndexes.x = _currentLocation.grid.GetLength(0) - 1;
                    _exitTileIndexes.y = _currentLocation.grid.GetLength(1) / 2;
                    break;

                case WorldSide.SOUTH:
                    _exitTileIndexes.x = _currentLocation.grid.GetLength(0) / 2;
                    _exitTileIndexes.y = 0;
                    break;

                case WorldSide.WEST:
                    _exitTileIndexes.x = 0;
                    _exitTileIndexes.y = _currentLocation.grid.GetLength(1) / 2;
                    break;
            }
        }

        private void InstantiateExitTile()
        {
            var exitTileIndexX = _exitTileIndexes.x;
            var exitTileIndexY = _exitTileIndexes.y;
            
            var tile = _currentLocation.grid[(int) exitTileIndexX, (int) exitTileIndexY];
            var tileGO = tile.gameObject;
            
            GameObject exitTileGO = Instantiate(_exitTilePrefab, tileGO.transform.position, Quaternion.identity, _contentPane);
            exitTileGO.GetComponent<ExitScript>().Initialize(_exitTileWorldSide);
            _currentLocation.grid[(int) exitTileIndexX, (int) exitTileIndexY].gameObject = exitTileGO;
        }
    }
}